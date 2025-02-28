namespace API.Extensions;

public static class DateTimeExtension
{
    public static int CalculateAge(this DateOnly dob)
    {
        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
        int age = currentDate.Year - dob.Year;
        if (dob>currentDate.AddYears(-age))
        {
            --age;
        }
        return age;
    }
}