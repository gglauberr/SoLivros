using System;

namespace SoLivros.Domain.Infrastructure
{
    public class SoLivrosException : Exception
    {
        public int CodResponse { get; private set; } = 500;
        public string Details { get; private set; } = string.Empty;
        public bool Recoverable { get; private set; } = false;

        public SoLivrosException()
            : this(message: "Houve um erro ao realizar a requisição.") { }

        public SoLivrosException(string message, Exception innerException = null)
            : this(message, details: string.Empty, innerException) { }


        public SoLivrosException(string message, int codResponse, Exception innerException = null)
            : this(message, codResponse, details: string.Empty, innerException) { }
        public SoLivrosException(string message, int codResponse, string details, Exception innerException = null)
            : this(message, codResponse, recoverable: false, details, innerException) { }


        public SoLivrosException(string message, bool recoverable, Exception innerException = null)
            : this(message, recoverable, string.Empty, innerException) { }

        public SoLivrosException(string message, bool recoverable, string details, Exception innerException = null)
            : this(message, codResponse: 500, recoverable, details, innerException) { }



        public SoLivrosException(string message, int codResponse, bool recoverable, string details, Exception innerException = null)
            : this(message, details, innerException)
        {
            CodResponse = codResponse;
            Recoverable = recoverable;
        }

        public SoLivrosException(string message, string details, Exception innerException = null)
          : base(message ?? "Houve um erro ao realizar a requisição.", innerException)
        { Details = details; }
    }
}
