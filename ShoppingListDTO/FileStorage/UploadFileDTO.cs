namespace ShoppingListDTO.FileStorage
{
    public class UploadFileDTO : BasicDTO<string>
    {
        public List<string> uploadedFiles { get; set; }
    }
}
