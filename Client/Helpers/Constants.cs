
namespace Datacar.Client.Helpers
{
    public static class Constants
    {
        //DB generic messages
        public const string NoRecords = "Não existem registos a mostrar";
        // Datacar roles
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Guest = "Guest";

        // sweet alert 
        public const string SWError = "Error";
        public const string SWSuccess = "Success";
        public const string SWWarning = "Warning";

        // sweet alert messages : system messages
        public const string AuthorizationFailed = "Erro no Login";        
        public const string RegistrationFailed = "Erro no Registo";
        public const string Logout = "Logout efetuado com sucesso";
        public const string NewUserCreated = "Novo utilizador criado com sucesso";
        public const string NewUserError = "Erro ao criar utilizador";
        public const string UpdatedUser = "Utilizador atualizado com sucesso";
        public const string UpdatedUserError = "Erro na atualização do utilizador";
        public const string RoleAssignedSuccess = "Role atribuído";
        public const string RoleMandatory = "Tem que seleccionar um role";
        public const string RoleRemovedSuccess = "Role removido";
        public const string ChangePasswordSuccess = "Password alterada com sucesso";
        public const string ChangePasswordError = "Erro na alteração de password";
        public const string PasswordsMismatch = "As novas passwords não são iguais";

    }
}
