using CLINICA_API.Areas.Cita.Data;
using CLINICA_API.Areas.General.Data;
using CLINICA_API.Areas.Procedimiento.Data;
using CLINICA_API.Modelo;
using Newtonsoft.Json;
using System.Data;

namespace CLINICA_API.Areas.Procedimiento.Service
{
    public class ProcedimientoService
    {
        private readonly ProcedimientoData _data;
        private readonly PacienteData _dataPaciente;
        public ProcedimientoService(ProcedimientoData data, PacienteData dataPaciente)
        {
            _data = data;
            _dataPaciente = dataPaciente;
        }
        public string ListarProcedimientoxFiltro(string fechainicio, string fechafin, string idsucursal)
        {
            var msJsonProcedimiento = _data.ListarProcedimientoxFiltro(fechainicio, fechafin, idsucursal);
            DataTable dtProcedimiento = new DataTable();
            dtProcedimiento = JsonConvert.DeserializeObject<DataTable>(msJsonProcedimiento.objeto.ToString());
            if (dtProcedimiento != null)
            {
                if (dtProcedimiento.Rows.Count > 0)
                {
                    Dictionary<string, string?> dIdPaciente = new();
                    foreach (DataRow row in dtProcedimiento.Rows)
                    {
                        //Paciente
                        string? idpacientebuscar = row["idpaciente"].ToString();
                        string? nombrepaciente = "";
                        if (dIdPaciente.ContainsKey(idpacientebuscar))
                        {
                            nombrepaciente = dIdPaciente.GetValueOrDefault(idpacientebuscar);
                        }
                        else
                        {
                            var msJsonPaciente = _dataPaciente.ObtenerPacientexIdPaciente(idpacientebuscar);
                            DataTable dtPaciente = new DataTable();
                            dtPaciente = JsonConvert.DeserializeObject<DataTable>(msJsonPaciente.objeto.ToString());
                            if (dtPaciente != null)
                                if (dtPaciente.Rows.Count > 0)
                                {
                                    nombrepaciente = dtPaciente.Rows[0]["paciente"].ToString();
                                    dIdPaciente.Add(idpacientebuscar, nombrepaciente);
                                }
                        }

                        row["paciente"] = nombrepaciente;
                    }
                }
            }
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtProcedimiento)));
        }
        public string GuardarEditarProcedimiento(string jsonprocedimiento)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarProcedimiento(jsonprocedimiento));
        }
        public string EliminarProcedimiento(string idprocedimiento)
        {
            return JsonConvert.SerializeObject(_data.EliminarProcedimiento(idprocedimiento));
        }
        public string ObtenerProcedimientoxIdPaciente_ModalProcedimientoPaciente(string idprocedimiento)
        {
            return JsonConvert.SerializeObject(_data.ObtenerProcedimientoxIdPaciente_ModalProcedimientoPaciente(idprocedimiento));
        }
        public string ListarTurno_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarTurno_Combo());
        }
    }
}
