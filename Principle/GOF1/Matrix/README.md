GOF1 - Felületre programozz, ne implementációra!

Feladat:

A gyakorló feladat lényege, hogy készíts egy programot, ami a Library könyvtárban lévõ MAF.EKE.GOF1 projekt segítségével képes kiszámolni egy négyzetes mátrix következõ adatait:
 - A mátrix fõátlójának összegét.
 - A mátrix melléktátlójának összegét.
 - A mátrix fõátló feletti elemeinek összegét.
 - A mátrix fõátló alatti elemeinek összegét.
 - A mellékátló feletti elemeinek összegét.
 - A mellékátló alatti elemeinek összegét.

 A program bármilyen felülettel készülhet, a lényege, hogy a felület értelmesen kommunikáljon a felhasználóval.

 A számításokhoz használd a MAF.EKE.GOF1 projekt QuadraticMatrix osztályát, ami a GOF1 elvnek megfelelõen lett elkészítve. 
 Nézd át a megvalósításhoz a QuadraticMatrix felületét. Fontos, hogy csak a felületét! 
 Az implementációs rész megtekintése tilos a feladat elvégzésének befejezéséig. (Utána meg már miért néznéd meg? Talán kíváncsi vagy? - Helyes!)

 További információk:

 A MAF.EKE.GOF1.Test projket a MAF.EKE.GOF1 projekt tesztje, bármennyire is meglepõ. Ha nem tudod, hogy kezdj neki a gyakorlatnak, itt megtekinthetõ a használata.
 Ha még ezek után se megy a dolog, akkor tekints bele a Program mappában található konzolos példába, ahol egy egyszerû megoldást találsz, de elõször próbáld meg önnálóan megoldani a feladatot.

 Mindenkinek jó gyakorlást!

 Megj.: A kiszolgáló projekthez szándékosan nem készítettünk interfészt, csak egy QuadraticMatrix osztályt, hogy jobban szemléltethetõ legyen a GOF1. Más esetben egy dll a szolgáltatásait jobban teszi, ha egy jól megtervezett és dokumentált interfészen keresztül nyújtja, ami nagy segítség lehet a továbbiakban.