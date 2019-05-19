using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MaestroMunicipos.Dtos;
using MaestroMunicipos.Logic;
using MaestroMunicipos.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MaestroMunicipos.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MunicipiosController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;

        public MunicipiosController(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region Insert Municipio 
        [HttpPost("[action]")]
        public AnswerResponseBE InsertMunicipio([FromBody]MunicipioBE IMUNI)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            MunicipioLogic ML = new MunicipioLogic( _appDbContext);
            AR = ML.InsertMunicipio(IMUNI);
            return AR;
        }
        #endregion


        #region Update Municipio
        [HttpPut("[action]")]
        public AnswerResponseBE UpdateMunicipio([FromBody]MunicipioBE UMUNI)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            MunicipioLogic ML = new MunicipioLogic( _appDbContext);
            AR = ML.UpdateMunicipio(UMUNI);
            return AR;
        }
        #endregion


        #region Search MunicipioId     
        [HttpGet("[action]")]
        public MunicipioBE SearchMunicipioId([FromQuery]int SEARIDMUNI)
        {
            MunicipioLogic MUNILIS = new MunicipioLogic(_appDbContext);
            var ARS = MUNILIS.SearchMunicipioId(SEARIDMUNI);
            return ARS;
        }
        #endregion


        #region Get Municipio All 
        [HttpGet("[action]")]
        public List<MunicipioBE> GetMunicipioAll()
        {
            List<MunicipioBE> ltsmunall = new List<MunicipioBE>();
            MunicipioLogic ML = new MunicipioLogic( _appDbContext);
            ltsmunall = ML.GetMunicipioAll();
            return ltsmunall;
        }
        #endregion


        #region Delete Municipio
        [HttpDelete("[action]/{id}")]
        public AnswerResponseBE DeleteMunicipio(int id)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            MunicipioLogic ML = new MunicipioLogic( _appDbContext);
            AR = ML.DeleteMunicipio(id);
            return AR;
        }
        #endregion

        #region Search MunicipioCod   
        [HttpGet("[action]/{SEARCODMUNI}")]
        public MunicipioBE SearchMunicipioCod(string SEARCODMUNI)
        {
            MunicipioLogic MUNILIS = new MunicipioLogic(_appDbContext);
            var ARS = MUNILIS.SearchMunicipioCod(SEARCODMUNI);
            return ARS;
        }
        #endregion
    }
}