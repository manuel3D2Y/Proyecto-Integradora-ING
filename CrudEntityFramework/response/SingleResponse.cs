using System.Collections.Generic;
using System.Linq;
using CrudEntityFramework.Excepciones;
using CrudEntityFramework.Utilerias;

namespace CrudEntityFramework.response
{
    public class SingleResponse<TResponse>
    {
        public TResponse Response { get; private set; }
        public bool IsOk { get; private set; }
        private Log log = new Log(typeof(SingleResponse<TResponse>));
        
        public string Message { get; private set; }
        private IList<Validation> validations;
        public IList<Validation> Validations
        {
            get
            {
                if (validations == null)
                {
                    validations = new List<Validation>();
                }
                return validations;
            }
            private set { validations = value; }
        }

        public SingleResponse(){}

        public SingleResponse(Log log)
        {
            this.log = log;
        }

        public void SetValidations(IList<Validation> validations)
        {
            this.validations = validations;
            Response = default(TResponse);
            IsOk = false;
            log.Warning("Error 2");
        }

        public void Done(TResponse response, string message, params object[] parameters)
        {
            Response = response;
            Message = string.Format(
                                    message,
                                    parameters);
            IsOk = true;
            //log.Info(Mensajes.SingleResponseInfo, Message);
        }

        public void Error(DomainException exception)
        {
            IsOk = false;
            Response = default(TResponse);
            Message = exception.Mensaje;
            if (exception.ErrorOrigen == null)
            {
                log.Error("Error 3", Message);
            }
            else
            {
                log.Error(exception.ErrorOrigen, "mesaje 1", Message);
            }
            
        }

        public void ThrowIfNotOk()
        {
            if (!IsOk && !Validations.Any())
            {
                throw new DomainException(Message);
            }
            if (!IsOk && Validations.Any())
            {
                throw new DomainValidationsException(Validations);
            }
        }
        
    }
}
