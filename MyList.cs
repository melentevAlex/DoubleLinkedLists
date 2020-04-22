using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkList
{
    public class MyList<T> : IEnumerable<T>
    {
        private Element<T> _firstEl; // ссылка на первый элемент
        private Element<T> _lastEl;
        int length;

        public int Length { get => length; }


        //Element<T>[] data; // создание переменной
        //int a; // создание переменной
        ////a = 2; // инициализация
        
        public MyList()
        {

        }
        public T this[int index]
        {
            get
            {

                Element<T> current = _firstEl;
                int i = 0;
                while (i < Length)
                {
                    if (i == index)
                    {
                        break;
                    }
                    i++;
                    current = current.Next;
                }
                return current.Data;
            }
        }


        public void AppEnd(T data)
        {
            Element<T> element = new Element<T>(data);
            if (_firstEl == null)
            {
                _firstEl = element;
            }
            else
            {
                _lastEl.Next = element; // у последнего элемента появился ссылка на следующий
                element.Previous = _lastEl;
            }
            _lastEl = element;
            length++;
        }
        public void Add(T data, int placeInList)
        {
            Element<T> element1 = new Element<T>(data); // создаём элемент
            if (placeInList < 1 || placeInList > Length+1) // место в списке не может быть меньше еденица и длины списка
            {
                throw new Exception("не верно указано место в списке");
            }
            if (placeInList == Length+1)
            {
                AppEnd(data);   // !!!!! НЕ ПЕРЕХОДИТ НА МЕТОД AppEnd!
            }
            Element<T> current = _firstEl;
            int currentPosition = 1;
            while (currentPosition != placeInList)
            {
                current = current.Next;
                currentPosition++;
            }
            current.Previous.Next = element1;
            element1.Previous = current.Previous;
            current.Previous = element1;
            element1.Next = current;

        }

        public void DeleteByIndex(int index)
        {
            if (index < 1 || index > Length)
            {
                throw new Exception("wrong index");
            }
            int currentPosition = 1;
            Element<T> current = _firstEl;
            while (currentPosition != index)
            {
                current = current.Next;
                currentPosition++;
            }

            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;
            length--;
        }

        public void Delete(T data)
        {
            Element<T> current = _firstEl;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    _lastEl = current.Previous;
                    _lastEl.Next = null;
                }
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    _firstEl = current.Next;
                    _firstEl.Previous = null;
                }
                length--;
            }


        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Element<T> current = _firstEl;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
