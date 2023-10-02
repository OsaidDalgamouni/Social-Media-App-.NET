namespace Service.Service
{
    public static class DateTimeExtentions
    {
        public static int Calulate(this DateTime date) 
        {
            var today =DateTime.UtcNow;
            var age =today.Year - date.Year;
            if (date > today.AddYears(-age)) age--;
            return age;

        }
    }
}
