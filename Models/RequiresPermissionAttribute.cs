namespace P_Asignación_de_Tareas.Models
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class RequiresPermissionAttribute : Attribute
    {
        public string Permission { get; }

        public RequiresPermissionAttribute(string permission)
        {
            permission = Permission; 
        }
    }
}
