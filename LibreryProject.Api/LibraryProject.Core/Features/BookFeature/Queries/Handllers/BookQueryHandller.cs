using AutoMapper;
using LibraryProject.Core.Bases;
using LibraryProject.Core.Features.BookFeature.Queries.Requests;
using LibraryProject.Core.Features.BookFeature.Queries.Responses;
using LibraryProject.Core.Shared;
using LibraryProject.Core.Wrappers;
using LibraryProject.Data.Entities;
using LibraryProject.Services.Services.BookService;
using LibraryProject.Services.Services.BorrowingService;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Linq.Expressions;

namespace LibraryProject.Core.Features.BookFeature.Queries.Handllers
{
    public class BookQueryHandller : ResponseHandler,
        IRequestHandler<GetBookByIdRequest, Response<GetBookByIdResponce>>
    {
        IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IBookService _bookService;
        private readonly IBorrowingService _borrowingService;
        private readonly IMapper _mapper;
        public BookQueryHandller(IStringLocalizer<SharedResources> stringLocalizer, IBookService bookService, IMapper mapper, IBorrowingService borrowingService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _bookService = bookService;
            _mapper = mapper;
            _borrowingService = borrowingService;
        }

        public async Task<Response<GetBookByIdResponce>> Handle(GetBookByIdRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetBookByIdAsync(request.Id);
            if (book == null) return NotFound<GetBookByIdResponce>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var BookMappimg = _mapper.Map<GetBookByIdResponce>(book);

            //pagenation
            Expression<Func<Borrowing, BorrowingResponce>> expression = e => new BorrowingResponce(e.UserID, e.UserID, e.BookID, e.User.LocalizeName(e.User.NameAr, e.User.NameEn), e.BorrowDate, e.ReturnDate);
            var queryable = _borrowingService.GetBorrowingsByBookId(request.Id);
            var pagenation = await queryable.Select(expression).ToPaginatedListAsync(request.Pagenumber, request.PageSize);

            BookMappimg.BorrowingsList = pagenation;
            return Success(BookMappimg);
        }
    }
}
