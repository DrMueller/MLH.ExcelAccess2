namespace MLH.ExcelAccess2.Test
{
    internal class Individual
    {
        public DateTime DateOfBirth { get; set; }
        public string Email { get; init; } = default!;
        public string FirstName { get; init; } = default!;
        public int Height { get; init; }
        public string LastName { get; init; } = default!;
    }
}