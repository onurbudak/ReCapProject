using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductDeleted = "Ürün Silindi";
        public static string ProductUpdated = "Ürün Güncellendi";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductsListed = "Ürünler Listelendi";

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerCompanyNameInvalid = "Müşteri Firma ismi Geçersiz";
        public static string CustomerListed = "Müşteri Listelendi";
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UserNameInvalid = "Kullanıcı ismi geçersiz";
        public static string UserListed = "Kullanıcı Listelendi";

        public static string RentalAdded = "Araba Kiralama Eklendi";
        public static string RentalDeleted = "Araba Kiralama  Silindi";
        public static string RentalUpdated = "Araba Kiralama  Güncellendi";
        public static string RentalNameInvalid = "Araba Kiralama gerçekleşmedi";
        public static string RentalListed = "Araba Kiralama  Listelendi";

        public static string FileExtensionInvalid = "Lütfen geçerli dosya formatı seçiniz";
        public static string CarImageLimitExceded = "Aynı arabaya ait en fazla 5 resim yüklenebilir";
        public static string FilePathInvalid = "Geçersiz dosya yolu";
        public  static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered="Kayıt oldu";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Parola hatası";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string AccessTokenCreated="Token Oluşturuldu";
    }
}
