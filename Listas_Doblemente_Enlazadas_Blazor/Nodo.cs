namespace Listas_Doblemente_Enlazadas_Blazor
{
    public class Nodo
    {
        public int Dato;
        public Nodo Anterior;
        public Nodo Siguiente;
        public Nodo(int dato)
        {
            Dato = dato;
            Anterior = null;
            Siguiente = null;
        }
    }
}
