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
    public class DepartamentosController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;

        public DepartamentosController( ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region Get Departamentos All 
        [HttpGet("[action]")]
        public List<DepartamentoBE> GetDepartamentoAll()
        {
            List<DepartamentoBE> lstdepto = new List<DepartamentoBE>();
            DepartamentoLogic DL = new DepartamentoLogic(_appDbContext);
            lstdepto = DL.GetDepartamentoAll();
            return lstdepto;
        }
        #endregion

        #region Insert Departamento 
        [HttpPost("[action]")]
        public AnswerResponseBE InsertDepartamento([FromBody]DepartamentoBE IDEPT)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            DepartamentoLogic DL = new DepartamentoLogic(_appDbContext);
            AR = DL.InsertDepartamento(IDEPT);
            return AR;
        }
        #endregion

        #region Update Departamento
        [HttpPut("[action]")]
        public AnswerResponseBE UpdateDepartamento([FromBody]DepartamentoBE UDEPT)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            DepartamentoLogic DL = new DepartamentoLogic(_appDbContext);
            AR = DL.UpdateDepartamento(UDEPT);
            return AR;
        }
        #endregion



        #region Delete Departamento
        [HttpDelete("[action]/{id}")]
        public AnswerResponseBE DeleteDepartamento(int id)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            DepartamentoLogic DL = new DepartamentoLogic(_appDbContext);
            AR = DL.DeleteDepartamento(id);
            return AR;
        }
        #endregion


    }
}