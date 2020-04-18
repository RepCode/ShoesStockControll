using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Elipgo.ShoeStock.Api.Constants;
using Elipgo.ShoeStock.Api.Dtos.Requests;
using Elipgo.ShoeStock.Api.Dtos.Responses;
using Elipgo.ShoeStock.Database.Models;
using Elipgo.ShoeStock.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Elipgo.ShoeStock.Api.Controllers
{
    [Route("services/articles")]
    [ApiController]
    [Authorize]
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
            var articles = _databaseProvider.GetStoreArticles(id);
            if (articles == null)
            {
                return NotFound(new ErrorResponse() { ErrorCode = 404, ErrorMessage = MessageConstants.StoreNotFoundMessage });
            }
            var response = new ArticlesListResponseDto() { TotalElements = articles.Count(), Articles = _mapper.Map<List<ArticleDto>>(articles) };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddArticleToStore(ArticleRequestDto article)
        {
            var articleDB = _mapper.Map<Article>(article);
            var store = _databaseProvider.GetStore(article.StoreId);
            if(store == null)
            {
                return NotFound(new ErrorResponse() { ErrorCode = 404, ErrorMessage = MessageConstants.StoreNotFoundMessage });
            }
            _databaseProvider.AddArticleToStore(articleDB);
            await _databaseProvider.Save();


            return CreatedAtAction("GetArticles", _mapper.Map<ArticleDto>(articleDB));
        }
    }
}