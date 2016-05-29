using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
    class PropertySpace : GameSpace
    {
        // Игрок, который владеет объектом.
        int ownedBy = 0;

        // Стоимость объекта.
        int cost;

        // Рента за этот объект.
        int rent;

        // Количество домов, которые находятся на этом объекте.
        int numHouses = 0;

        /// <summary>
        /// Устанавливает значения объекта по умолчанию.
        /// </summary>
        /// <param name="spaceCost"> Сколько объект будет стоить. </param>
        public PropertySpace(int spaceCost) : base("Объект")
        {
            ownedBy = -1;
            cost = spaceCost;
            rent = spaceCost / 2;
            numHouses = 0;
        }

        /// <summary>
        /// Добавляет дом в собственность после проверки,
        /// является игрок владельцем объекта.
        /// </summary>
        /// <param name="playerNum"> Индекс текущего игрока. </param>
        /// <param name="curPlayer"> Объект текущего игрока. </param>
        public override void addHouse(int playerNum, ref Player curPlayer)
        {
            if (!(numHouses>=5))
            {
            if (ownedBy != playerNum) return;

            DialogResult dr = MessageBox.Show( "Желаете приобрести дом?" ,"Добавление дома на улице" , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                return;

            
            if (ownedBy == playerNum && curPlayer.getMoney() > cost / 2)
            {
                numHouses++;
                rent += cost / 2;
                curPlayer.updateMoney(-cost/2);
            }
                return;
            }
            else MessageBox.Show( "Вы уже купили все дома на этой улице." ,"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        ///  Возвр количество домов на улице.
        /// </summary>
        /// <returns> Количество домов на улице. </returns>
        int getNumHouse() { return numHouses; }

        /// <summary>
        /// Возвр цену дома, для его добавления.
        /// </summary>
        /// <returns> Цена дома. </returns>
        int getHouseCost() { return cost / 2; }

        /// <summary>
        /// Возвр ренту. Определение метода для получения ренты
        /// </summary>
        /// <returns></returns>
        public override int getRent() { return rent; }

        /// <summary>
        ///  Возвр владельца объекта.
        /// </summary>
        /// <returns> Владелец объекта. </returns>
        public override int getOwner() { return ownedBy; }

        public void  setOwner() { ownedBy = 0; }

        /// <summary>
        ///Назначает объект в собственность игроку
        /// </summary>
        /// <param name="playerNum"> Индекс текущего игрока. </param>
        /// <param name="curPlayer"> Объект текущего игрока </param>
        public void buyProperty(int playerNum, ref Player curPlayer)
        {   
            if (ownedBy != playerNum && curPlayer.getMoney() > cost)
            {
                ownedBy = playerNum;
                curPlayer.updateMoney(-cost);
            }
            
            return;
        }

        /// <summary>
        /// Если объект не принадлежит текущему игроку (но пренадлежит др. игроку), взимаем арендную плату.
        /// Если объект не принадлежит никому, 
        /// спрашиваем текущего игрока, желает ли он приобрести его.
        /// </summary>
        /// <param name="playerNum"> Индекс текущего игрока. </param>
        /// <param name="curPlayer"> Объект текущего игрока. </param>
        /// <returns> Арендная плата(если будет взиматься, если нет, то возвр 0) </returns>
        public override int doAction(ref int playerNum, ref Player curPlayer)
        {
            // Рента
            if (ownedBy != playerNum && ownedBy != -1)
            {
                curPlayer.updateMoney(-rent);
                playerNum = ownedBy;
                return rent;
                
            }

            // Свободный объект
            else if (ownedBy == -1)
            {
                DialogResult dr = MessageBox.Show("Желаете приобрести эту улицу?","Покупка улицы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    buyProperty(playerNum, ref curPlayer);
                History = "Игрок №" + playerNum + " приобрел улицу " + curPlayer;
                return 0;
            }

            return 0;
        }
    }
}
