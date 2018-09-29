using System;

namespace BlogTJMT.Common.Validations
{
    public static class ValidationClass
    {
        public static void ValidaClasse<T>(T classe)
        {
            if (classe == null)
                throw new Exception($"Classe: {nameof(classe)} inválida.");
        }
    }
}
