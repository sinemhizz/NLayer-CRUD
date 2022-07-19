using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }
        public List<String> Errors { get; set; }

        //bir endpoint ile istek yaptığımızda geriye mutlaka bir durum kodu almak zorundayız.

        [JsonIgnore] //statusCode un clientlara (Canlı ortam)a dönmemesini sağlıyoruz.
        public int StatusCode { get; set; }

        //Geri dönüş (success,fail..) yapması için statik methodlar düzenliyoruz.

        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode, Errors=null };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> {StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Fail(int statusCode, List<String> errors)
        {
            return new CustomResponseDto<T> {StatusCode = statusCode, Errors = errors };
        }

        //birçok hata gelirse list şeklinde (yukarıdaki) tek hata gelirse tek bir error tanımlayabiliriz.

        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string>{ error } };
        }

    }
}
