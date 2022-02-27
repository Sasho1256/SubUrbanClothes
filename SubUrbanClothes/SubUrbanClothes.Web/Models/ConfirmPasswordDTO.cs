namespace SubUrbanClothes.Web.Models
{
    public class ConfirmPasswordDTO
    {
        public ConfirmPasswordDTO()
        {

        }
        public ConfirmPasswordDTO(string confirmPassword)
        {
            this.ConfirmPassword = confirmPassword;
        }

        public string ConfirmPassword { get; set; }
    }
}
