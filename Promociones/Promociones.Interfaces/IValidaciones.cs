/// <summary>
/// 
/// </summary>
namespace Promociones.Interfaces
{
    using Promociones.Entidades;

    public interface IValidaciones
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        bool validarInsertUpdate(Promocion p);
    }
}
