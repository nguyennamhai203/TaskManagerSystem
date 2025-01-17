namespace App_TaskManagerSystem.HelpersApp
{
    public static class AreaHelper
    {
        public static string GetAreaName(string role)
        {
            switch (role)
            {
                case "Admin":
                    return "Admin";
                case "Manager":
                    return "Manager";
                case "User":
                    return "User";
                default:
                    return "Default"; // Or any default area
            }
        }
    }
}
