using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //ASPECTS yani bsaındami sonunda mı demek
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulamam sınıf değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//reflection çalışm anında birşeyleri çalıştırmamızı sağlıyor
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//prodctvalidator base typenı bul, onun generic argumanlarında ilkini bul 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //invocation=method demekp productın parametrelirin bul
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
