namespace Listas_Doblemente_Enlazadas_Blazor
{
    public class ListasDoblementeEnlazadas
    {
        private Nodo cabeza;
        private Nodo cola;

        public ListasDoblementeEnlazadas()
        {
            cabeza = null;
            cola = null;
        }

        // Método para agregar un nodo al final de la lista
        public void AgregarAlFinal(int dato)
        {
            Nodo nuevo = new Nodo(dato);
            if (cabeza == null)
            {
                cabeza = cola = nuevo;
            }
            else
            {
                cola.Siguiente = nuevo;
                nuevo.Anterior = cola;
                cola = nuevo;
            }
        }

        // Método para agregar un nodo al inicio de la lista
        public void AgregarAlInicio(int dato)
        {
            Nodo nuevo = new Nodo(dato);
            if (cabeza == null)
            {
                cabeza = cola = nuevo;
            }
            else
            {
                nuevo.Siguiente = cabeza;
                cabeza.Anterior = nuevo;
                cabeza = nuevo;
            }
        }


        // Método para agregar un nodo antes de un dato X
        public void AgregarAntesDe(int x, int dato)
        {
            Nodo actual = cabeza;
            while (actual != null && actual.Dato != x)
            {
                actual = actual.Siguiente;
            }

            if (actual != null)
            {
                Nodo nuevo = new Nodo(dato);
                nuevo.Siguiente = actual;
                nuevo.Anterior = actual.Anterior;

                if (actual.Anterior != null)
                {
                    actual.Anterior.Siguiente = nuevo;
                }
                else
                {
                    cabeza = nuevo;
                }

                actual.Anterior = nuevo;
            }
        }

        // Método para agregar un nodo después de un dato X
        public void AgregarDespuesDe(int x, int dato)
        {
            Nodo actual = cabeza;
            while (actual != null && actual.Dato != x)
            {
                actual = actual.Siguiente;
            }

            if (actual != null)
            {
                Nodo nuevo = new Nodo(dato);
                nuevo.Siguiente = actual.Siguiente;
                nuevo.Anterior = actual;

                if (actual.Siguiente != null)
                {
                    actual.Siguiente.Anterior = nuevo;
                }
                else
                {
                    cola = nuevo;
                }

                actual.Siguiente = nuevo;
            }
        }

        // Método para agregar un nodo en una posición específica
        public void AgregarEnPosicion(int posicion, int dato)
        {
            if (posicion < 0) return;

            Nodo nuevo = new Nodo(dato);
            if (posicion == 0)
            {
                AgregarAlInicio(dato);
                return;
            }

            Nodo actual = cabeza;
            for (int i = 0; actual != null && i < posicion - 1; i++)
            {
                actual = actual.Siguiente;
            }

            if (actual == null) return;

            nuevo.Siguiente = actual.Siguiente;
            nuevo.Anterior = actual;

            if (actual.Siguiente != null)
            {
                actual.Siguiente.Anterior = nuevo;
            }
            else
            {
                cola = nuevo;
            }

            actual.Siguiente = nuevo;
        }

        // Método para agregar un nodo antes de una posición específica
        public void AgregarAntesDePosicion(int posicion, int dato)
        {
            if (posicion <= 0)
            {
                AgregarAlInicio(dato);
                return;
            }
            AgregarEnPosicion(posicion - 1, dato);
        }

        // Método para agregar un nodo después de una posición específica
        public void AgregarDespuesDePosicion(int posicion, int dato)
        {
            AgregarEnPosicion(posicion + 1, dato);
        }


        /// ////////// ////////// ///
        // METODOS DE ELIMINACION //
        /// ////////// ////////// ///

        // Método para eliminar un elemento al inicio de la lista
        public void EliminarInicio()
        {
            if (cabeza == null) return;
            cabeza = cabeza.Siguiente;
            if (cabeza != null) cabeza.Anterior = null;
            else cola = null;
        }

        // Método para eliminar un elemento al final de la lista
        public void EliminarFinal()
        {
            if (cola == null) return;
            cola = cola.Anterior;
            if (cola != null) cola.Siguiente = null;
            else cabeza = null;
        }

        // Método para eliminar un nodo antes de un dato X
        public void EliminarAntesDe(int x)
        {
            Nodo actual = cabeza;
            while (actual != null && actual.Dato != x)
            {
                actual = actual.Siguiente;
            }
            if (actual != null && actual.Anterior != null)
            {
                Nodo nodoAEliminar = actual.Anterior;
                if (nodoAEliminar.Anterior != null)
                {
                    nodoAEliminar.Anterior.Siguiente = actual;
                    actual.Anterior = nodoAEliminar.Anterior;
                }
                else
                {
                    cabeza = actual;
                    actual.Anterior = null;
                }
            }
        }

        // Método para eliminar un nodo después de un dato X
        public void EliminarDespuesDe(int x)
        {
            Nodo actual = cabeza;
            while (actual != null && actual.Dato != x)
            {
                actual = actual.Siguiente;
            }
            if (actual != null && actual.Siguiente != null)
            {
                Nodo nodoAEliminar = actual.Siguiente;
                actual.Siguiente = nodoAEliminar.Siguiente;
                if (nodoAEliminar.Siguiente != null)
                {
                    nodoAEliminar.Siguiente.Anterior = actual;
                }
                else
                {
                    cola = actual;
                }
            }
        }

        // Método para eliminar un nodo en una posición específica
        public void EliminarEnPosicion(int posicion)
        {
            if (posicion < 0 || cabeza == null) return;
            Nodo actual = cabeza;
            for (int i = 0; actual != null && i < posicion; i++)
            {
                actual = actual.Siguiente;
            }
            if (actual == null) return;
            if (actual.Anterior != null) actual.Anterior.Siguiente = actual.Siguiente;
            else cabeza = actual.Siguiente;
            if (actual.Siguiente != null) actual.Siguiente.Anterior = actual.Anterior;
            else cola = actual.Anterior;
        }

        public void Ordenar()
        {
            if (cabeza == null) return;

            bool intercambio;
            do
            {
                intercambio = false;
                Nodo actual = cabeza;

                while (actual.Siguiente != null)
                {
                    if (actual.Dato > actual.Siguiente.Dato)
                    {
                        int temp = actual.Dato;
                        actual.Dato = actual.Siguiente.Dato;
                        actual.Siguiente.Dato = temp;
                        intercambio = true;
                    }
                    actual = actual.Siguiente;
                }
            } while (intercambio);
        }
        public List<int> ObtenerElementos()
        {
            List<int> elementos = new List<int>();
            Nodo actual = cabeza;
            while (actual != null)
            {
                elementos.Add(actual.Dato);
                actual = actual.Siguiente;
            }
            return elementos;
        }

    }
}
