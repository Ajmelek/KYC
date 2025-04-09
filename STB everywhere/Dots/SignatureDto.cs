// Dtos/SignatureDto.cs
using System;

namespace STB_everywhere.Dtos
{
    public class SignatureDto
    {
        public string SignatureData { get; set; } // Base64 string
        public DateTime SignatureDate { get; set; } = DateTime.UtcNow;
    }
}