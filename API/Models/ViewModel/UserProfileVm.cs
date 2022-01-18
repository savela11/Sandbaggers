namespace API.Models.ViewModel;

public class UserProfileVm
{
    public UserProfileVm(string firstName, string lastName, decimal handicap, string image)
    {
        FirstName = firstName;
        LastName = lastName;
        Handicap = handicap;
        Image = image;
    }


    public string Image { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public decimal Handicap { get; set; }
}