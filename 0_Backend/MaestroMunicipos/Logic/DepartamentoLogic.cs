using AutoMapper;
using MaestroMunicipos.Dtos;
using MaestroMunicipos.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaestroMunicipos.Logic
{
    public class DepartamentoLogic
    {
        private readonly ApplicationDbContext _appDbContext;

        public DepartamentoLogic( ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region Get all Departamentos
        public List<DepartamentoBE> GetDepartamentoAll()
        {
            List<DepartamentoBE> lstdepto = new List<DepartamentoBE>();

            try
            {
                lstdepto = (from Departamento in _appDbContext.Departamento

                            select new DepartamentoBE
                            {
                                DepartamentoId = Departamento.DepartamentoId,
                                Nombre = Departamento.Nombre,
                                Codigo = Departamento.Codigo,
                            }).OrderBy(x => x.Nombre).ToList();
            }
            catch (Exception EX)
            {

            }
            finally
            {
                _appDbContext.Dispose();
            }

            return lstdepto;
        }
        #endregion

        #region Insert Departamento
        public AnswerResponseBE InsertDepartamento(DepartamentoBE IDEPT)
        {
            AnswerResponseBE AR = new AnswerResponseBE();

            try
            {
                int CountMuni = 0;
                CountMuni = _appDbContext.Departamento.Where(x => x.DepartamentoId == IDEPT.DepartamentoId).ToList().Count();
                if (CountMuni == 0)
                {
                    Departamento Departamento = new Departamento();
                    Departamento.Nombre = IDEPT.Nombre;
                    Departamento.Codigo = IDEPT.Codigo;

                    _appDbContext.Departamento.Add(Departamento);
                    _appDbContext.SaveChanges();

                    AR.CodeError = 0;
                    AR.DescriptionError = "Se ha insertado el Departamento correctamente";
                }
                else
                {
                    AR.CodeError = 2;
                    AR.DescriptionError = "El Departamento ya existe, por favor verifique la información";
                }
            }
            catch (Exception EX)
            {
                AR.CodeError = 1;
                AR.DescriptionError = "Hubo un error";
            }
            finally
            {
                _appDbContext.Dispose();
            }
            return AR;
        }
        #endregion

        #region Update Departamento
        public AnswerResponseBE UpdateDepartamento(DepartamentoBE UDEPT)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            try
            {
                Departamento Departamento = new Departamento();
                Departamento = _appDbContext.Departamento.Where(x => x.DepartamentoId == UDEPT.DepartamentoId).FirstOrDefault();
                if (Departamento != null)
                {
                    Departamento.Nombre = UDEPT.Nombre;
                    Departamento.Codigo = UDEPT.Codigo;

                    _appDbContext.SaveChanges();

                    AR.CodeError = 0;
                    AR.DescriptionError = "Se ha actualizado el Departamento correctamente";
                }
                else
                {
                    AR.CodeError = 2;
                    AR.DescriptionError = "El registro no existe, por favor verifique la información";
                }
            }
            catch (Exception EX)
            {
                AR.CodeError = 1;
                AR.DescriptionError = "Hubo un error";
            }
            finally
            {
                _appDbContext.Dispose();
            }
            return AR;
        }
        #endregion

        #region Delete Departamento
        public AnswerResponseBE DeleteDepartamento(int id)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            try
            {
                Departamento Departamento = new Departamento();
                Departamento = _appDbContext.Departamento.Where(x => x.DepartamentoId == id).FirstOrDefault();
                if (Departamento != null)
                {
                    _appDbContext.Remove(Departamento);
                    _appDbContext.SaveChanges();

                    AR.CodeError = 0;
                    AR.DescriptionError = "Se ha eliminado el Departamento correctamente";
                }
                else
                {
                    AR.CodeError = 2;
                    AR.DescriptionError = "El registro no existe, por favor verifique la información";
                }
            }
            catch (Exception EX)
            {
                AR.CodeError = 1;
                AR.DescriptionError = "Hubo un error";
            }
            finally
            {
                _appDbContext.Dispose();
            }
            return AR;
        }
        #endregion
    }
}
