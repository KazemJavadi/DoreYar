using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DbStrLenInfo
{
    public static class DbStrMaxLen
    {
        //Deck
        public const int DeckNameLen = 500;
        public const int DeckDescriptionLen = 1000;
        public const int DeckHeaderImageNameLen = 200;

        //Card
        public const int CardQuestionLen = 1000;
        public const int CardAnswerLen = int.MaxValue;

        //CardImage
        public const int CardImageFileNameLen = DeckHeaderImageNameLen;

    }
}
