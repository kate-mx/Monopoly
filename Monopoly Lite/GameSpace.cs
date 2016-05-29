using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class GameSpace
    {

        // Строка с типом клетки.
        private string SpaceType;

        // Случайный объект для клетки "Шанс" 
        protected Random rand = new Random();

        /// <summary>
        /// Пустой параметр без перегрузки
        /// </summary>
        public GameSpace()
        {
        }

        //строка истории
        public string History;

        /// <summary>
        /// Определяет тип клетки
        /// </summary>
        /// <param name="iniSpaceType"> Тип клетки </param>
        public GameSpace(string iniSpaceType)
        {
            SpaceType = iniSpaceType;
        }

        /// <summary>
        /// Переопределяет метод для класса Player
        /// </summary>
        /// <param name="PlayerNum"> Индекс текущего игрока. </param>
        /// <param name="CurPlayer"> Объект текущего игрока. </param>
        /// <returns> </returns>
        public virtual int doAction(ref int PlayerNum, ref Player CurPlayer) { return 0; }

        /// <summary>
        /// Переопределяет метод добавления дома
        /// </summary>
        /// <param name="playerNum"> Индекс текущего игрока. </param>
        /// <param name="curPlayer"> Объект текущего игрока. </param>
        public virtual void addHouse(int playerNum, ref Player curPlayer) { return; }

        /// <summary>
        /// Владелец (переопр)
        /// </summary>
        /// <returns> </returns>
        public virtual int getOwner() { return -1; }

        /// <summary>
        /// Рента (переопр)
        /// </summary>
        /// <returns></returns>
        public virtual int getRent() { return 0; }

        /// <summary>
        /// Возвращает тип клетки
        /// </summary>
        /// <returns> Какого типа клетка (возвр). </returns>
        public string GetSpaceType()
        {
            return SpaceType;
        }
    }
}
