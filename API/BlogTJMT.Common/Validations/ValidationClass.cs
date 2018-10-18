using BlogTJMT.Common.Resources;
using System;

namespace BlogTJMT.Common.Validations
{
    public static class ValidationClass
    {
        public static void ValidaClasse<T>(T classe)
        {
            if (classe == null)
                throw new Exception(MensagensErro.ClasseInvalida);
        }
    }
}
