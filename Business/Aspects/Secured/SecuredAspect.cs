using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Aspects.Secured
{
    public class SecuredAspect : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _HttpContextAccessor;

        /////////1  1-2 arası yalnızca giriş yapmamın yeterliliğini oluşturur.
        public SecuredAspect()
        {
            _HttpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        /////////2
        public SecuredAspect(string roles)
        {
            _roles=roles.Split(',');
            _HttpContextAccessor=ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {     ////////////////1  1-2 arası harici diğer kod blokları metottan silinirse sadece yetki ataması yaparak içeriğe ulaşılabilir. diğer yapıda bir rol göndermesem dahi giriş yapmış olmam içeriği görmeme yeterlidir.
            if (_roles != null)
            {
                var roleClaims = _HttpContextAccessor.HttpContext.User.ClaimsRoles();
                foreach (var role in _roles)
                {
                    if (roleClaims.Contains(role))
                    {
                        return;
                    }
                }
                throw new Exception("İşlem için yetkiniz bulunmuyor");
            } ////////////////2
            else
            {
                var claims=_HttpContextAccessor.HttpContext.User.Claims;
                if (claims.Count()>0)   
                {
                    return;
                }
                throw new Exception("İşlem için yetkiniz bulunmuyor");
            }
            
        }
    }
}
