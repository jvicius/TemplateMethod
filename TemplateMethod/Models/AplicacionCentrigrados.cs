namespace TemplateMethod.Models
{
    public abstract class AplicacionCentrigrados
    {
        private bool _isDone;
        protected abstract void Iniciar();
        protected abstract void Trabajar();
        protected abstract void Limpiar();

        protected void SetDone()
        {
            _isDone = true;
        }

        protected bool Done()
        {
            return _isDone;
        }

        public void EjecutarAplicacion()
        {
            Iniciar();
            while (!Done())
            {
                Trabajar();
            }
            Limpiar();
        }
    }
}
