using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Elipgo.ShoeStock.Api.Constants;
using Elipgo.ShoeStock.Api.Dtos.Responses;
using Elipgo.ShoeStock.Provider;
using Microsoft.AspNetCore.Mvc;

namespace Elipgo.ShoeStock.Api.Controllers
{
    [Route("services/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        protected readonly IDatabaseProvider _databaseProvider;
        protected readonly IMapper _mapper;
        public ArticlesController(IDatabaseProvider databaseProvider, IMapper mapper) : base()
        {
            _databaseProvider = databaseProvider;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetArticles()
        {
            var articles = _databaseProvider.GetArticles().ToList();
            var response = new ArticlesListResponseDto() { TotalElements = articles.Count(), Articles = _mapper.Map<List<ArticleDto>>(articles) };
            return Ok(response);
        }

        [HttpGet]
        [Route("stores/{id}")]
        public IActionResult GetStoreArticles(int id)
        {
            var articles = _databaseProvider.GetStoreArticles(1);
            if (articles == null)
            {
                return NotFound(new ErrorResponse() { ErrorCode = 404, ErrorMessage = MessageConstants.StoreNotFoundMessage });
            }
            var response = new ArticlesListResponseDto() { TotalElements = articles.Count(), Articles = _mapper.Map<List<ArticleDto>>(articles) };
            return Ok(response);
        }
    }
}