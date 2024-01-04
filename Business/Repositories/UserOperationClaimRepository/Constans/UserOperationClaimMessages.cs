using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.UserOperationClaimRepository.Constans
{
    public class UserOperationClaimMessages
    {
        public static string AddedUserOperationClaim = "Yetki ataması başarıyla oluştuldu";
        public static string UpdateUserOperationClaim = "Yetki ataması başarıyla güncellendi";
        public static string DeleteUserOperationClaim = "Yetki ataması başarıyla silindi";
        public static string IsOperationClaimSetExist = "Bu yetki zaten atanmış";
        public static string OperationClaimExist = "Seçtiğiniz yetki bilgisi yetkilerde bulunmuyor";
        public static string UserNotExist = "Seçtiğiniz kullanıcı  bulunamadı";
    }
}
