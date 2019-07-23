SRP (Single Responsibility Principle) - Egy felel�ss�g egy oszt�ly alapelve

Feladat:
Adott az SRP\Hanoi\Program\MAF.EKE.SRP.HanoiDemo projekt. Ez a projekt egy Hanoi dem�t val�s�t meg n�gy koronggal konzolos fel�leten. A feladatunk csup�n annyi, hogy �rjuk �t a dem�t �gy, hogy a felhaszn�l� adhassa meg a korongok sz�mait 1 �s 15 k�z�tt, ahol minden korong sz�ne m�s, ill. fekete sz�n� nem lehet a korong. Fontos, hogy a konzolon fut� dem� tov�bbra is megfelel�en m�k�dj�n (pl. ne essen sz�t a dem� a konzolos ablakon, ne cs�sszon ki a l�that� k�perny�r�l stb.), b�rmilyen sz�mot is ad meg a felhaszn�l� a megengedett intervallumban. A feladatunkat nehez�ti, hogy ez egy rothad� k�d vagy m�s n�ven spagetti k�d. A k�dot a megfelel� ir�nyba refaktor�l�ssal terelj�k. Fejleszt�s k�zben tartsuk be a GOF1, GOF2 �s SRP elveket.

Ha nem boldogulunk a feladattal, akkor a k�vetkez� p�ld�t:
 - A Library k�nyvt�r MAF.EKE.SRP.Hanoi projektje a szolg�ltat�st val�s�tja meg.
 - A Program k�nyvt�r MAF.EKE.SRP.HanoiDemo2 a konzolos ki�r�st mutatja be.

A HanoiDemo �s HanoiDemo2 konzolos p�ldaprogramokat hasonl�tsuk �ssze, hogy mennyivel lett egyszer�bb.

Mindenkinek j� gyakorl�st!


Ha els�re nem siker�lt, ne keseredj el, ink�bb olvasd el az itteni seg�ts�get, ahol l�p�sr�l l�p�sre le van �rva a feladat megval�s�t�s�nak menete.
Mivel a korongok sz�m�t egy v�ltoz� t�rolja, ami jelenleg 4-re van �ll�tva, adn� mag�t a lehet�s�g, hogy �rjuk �t 5-re. Ez viszont egy rothad� k�d, ahogy ezt megpr�b�ln�nk, m�ris sz�tcs�szna a konzolos ablak. Azt kell ilyenkor �szrevenni, hogy elengedhetetlen a refaktor�l�s. Ebben a kicsi p�ld�ban ak�r azt is megtehetn�nk, hogy �jra�rjuk az eg�szet, betartva az elveket, de itt most a refaktor�l�st is szeretn�nk gyakorolni. Teh�t j�jj�n a refaktor�l�s menete: 
 - Az els� l�p�s, hogy a fel�letet v�lasszuk el a logik�t�l. Ha az lett volna a feladat, hogy a fel�letet cser�lj�k le grafikus fel�letre szint�n nem tudtuk volna megtenni, mert a fel�let �s a logika egy oszt�lyban van megval�s�tva. Mi most k�sz�ts�nk egy k�nyvt�rt, hogy oda �t tudjuk majd tenni a logik�t. A fenti megoldott p�ld�ban ez a MAF.EKE.SRP.Hanoi projekt.
 - Ha elk�sz�tett�k a logik�t megval�s�t� projektet, akkor hozzunk l�tre benne egy Hanoi oszt�lyt.
 - Hozzuk l�tre a konstruktort, ami 1 param�tert v�r, a korongok sz�m�t, amit elment�nk egy priv�t mez�be, de olvas�sra publikuss� tessz�k (property).
 - Az oszt�ly m�k�d�s�t t�bbf�le k�ppen megval�s�thatn�nk, mi most az egyszer�s�g kedv��rt azt a megold�st v�lsztjuk, amikor a konstruktor m�r el�re kisz�molja a l�p�seket �s elt�rolja �s a tov�bbiakban csup�n inform�ci�szolg�ltat�st ny�jt. Szerencs�re a programunk nem annyira rothat�, a logika nagy r�sz�t 2 f�ggv�ny v�gzi el, ezeket fogjuk �ttenni. Ez a k�t f�ggv�ny az eredeti k�dban a Hanoi �s a HanoiA. Ezeket �temelj�k a logikai r�szbe.
 - A Hanoi f�ggv�nyt �tnevezz�k CalcHanoi n�vre.
 - A f�ggv�nek ne legyenek statikusak, a static kulcssz�t t�r�lj�k.
 - A Tuple oszt�lyok haszn�lat�t meg kell sz�ntetni. Ez szembe megy a GOF1 alapelvel �s Bob b�csi se szereti ha egy v�ltoz�nak a nev�b�l nem der�l ki, hogy � mi is pontosan, m�rpedig a Tuple �ltal egybefogott v�ltoz�khoz csak t�pus van megadva vagyis nincs is nev�k. L�trehozzuk a Step oszt�lyt, amivel majd kiv�ltjuk a Tuple oszt�lyt. A Step oszt�ly megval�s�t�s�t megtal�lod a Step.cs f�jlban.
 - A Hanoi.cs f�jlban lecser�lj�k a Tuple oszt�lyt mindenhol Step oszt�lyra.
 - A konstruktorban megh�vjuk a CalcHanoi f�ggv�nyt, de a visszat�r�si �rt�k�t egy priv�t v�ltoz�ba elt�roljuk.
 - A CalcHanoi f�ggv�ny �ltal kisz�molt �s priv�t v�ltoz�ba mentett list�t publik�ljuk kifel� a StepList v�ltoz�ban, ami egy IReadOnlyList t�pus� v�ltoz�. Ezt is t�bbf�lek�ppen megoldhattuk volna, mi itt most �gy oldottuk meg azt, hogy a priv�t list�hoz ne f�rjenek hozz�, de az�rt az adatokat le tudj�k k�rdezni.
Remek! Eddig a logik�t sikeresen leszak�tottuk a fel�letr�l. Ez volt a k�nnyebb r�sz. Mivel a HanoiDemo projektbe itt most nem lehet bele�rni, mert ez maga a feladat, ez�rt l�trehoztam egy HanoiDemo2 projektet a Program mapp�ba, amibe �tm�soltam a HanoiDemo megval�s�t�s�t �s �gy a tov�bbiakban a HanoiDemo2 k�dot refaktor�ltam, vagyis a refaktor�lt fel�let itt tekinthet� meg.
Akkor l�ssuk a tov�bbi l�p�seket:
 - A Hanoi �s a HanoiA f�ggv�nyekre m�r nincs sz�ks�g itt ez�rt ezekeet t�r�lj�k, de ez m�g nem el�g, mert a Main hivatkozott a Hanoi f�ggv�nyre. A HanoiDemo2 referenci�j�hoz hozz�adjuk a MAF.EKE.SRP projektet, majd a Main-beli f�ggv�ny hivatkoz�s el�tt l�trehozzunk egy Hanoi p�ld�nyt, valamint a hivatkoz�st �t�rjuk, hogy mostm�r a Hanoi p�ld�nyt�l vegye az adatokat. Ez m�g mindig nem el�g a ResultList v�ltoz�nk itt m�g Tuple t�pus�. Jav�tjuk mindenhol, hogy Step t�pus� legyen �s a ResultList v�ltoz�t t�r�lj�k.
 - Azt tal�ljuk a k�dban, hogy az �ltalunk megsz�ntetett ResultList v�ltoz�t Count �rt�k�t is felhaszn�lt�k. Ezt jav�thatn�nk �gy, hogy a Hanoi p�ld�ny LepesekList�ja v�ltoz� Count-j�t haszn�ljuk fel, de ezzel megs�rten�nk Demeter t�rv�ny�t, ez�rt a Hanoi oszt�lyt b�v�tj�k �gy, hogy legyen L�p�sekSz�ma propertyje, ami ezt az adatot adja vissza.
 - Nagyon j�, hogy elk�sz�tett�k a L�p�sekList�ja v�ltoz�t a Hanoi oszt�lyban, de val�j�ban ezt az oszt�lyt kont�ner oszt�lyk�nt kell haszn�ljuk, ez�rt kap egy kis kieg�sz�t�st.
 - A programunk ism�t teszi a dolg�t, csak a logikai r�szt m�r kiszervezt�k. Viszont a korongok sz�m�t m�g mindig nem lehet n�velni. Ehhez tov�bbi refaktor�l�s sz�ks�ges, melyekb�l most az k�vetkezik, hogy a Hanoi p�ld�nyt kitessz�k priv�t oszt�lyszint� v�ltoz�v�, hogy a t�bbi f�ggv�ny is el�rhesse.
 - Kezdj�k el a Main f�ggv�ny refaktor�l�s�t. El�sz�r is a main elej�n rakjuk rendbe az ablakot. T�r�lj�k a konzol ablakot, majd �rjuk ki, hogy h�ny korongos Hanoi tornyai dem� fut �ppen.
 - Kezden�nk kell valamit azzal is, hogy ha fut�s k�zben �tm�retezik az ablakot, akkor sz�tesik minden. Ez ellen k�tf�le k�pen v�dekezhet�nk. Vagy letiltjuk az ablak m�retezhet�s�g�t, vagy minden kirajzol�sn�l a teljes k�perny�t �jra rajzoljuk. Mindkett� teljesen m�s megold�st k�n�l, mi most a k�perny� m�retez�s�nek letilt�s�t v�lasztjuk. Ehhez egy kis seg�ts�g itt tal�lhat�: https://social.msdn.microsoft.com/Forums/vstudio/en-US/1aa43c6c-71b9-42d4-aa00-60058a85f0eb/c-console-window-disable-resize?forum=csharpgeneral
 - Hogy a k�d eszt�tikumon is jav�tsunk a korongokSzama v�ltoz�t refaktor�ljuk numberOfDisks v�ltoz�ra.
 - A k�perny�t �trendezz�k. Bal oldalra kirajzoljuk a korongokat. A kirajzol� for ciklust kiszervezz�k egy DrawDisks f�ggv�nybe �s a f�ggv�ny h�v�s�t �thelyezz�k k�zvetlen�l a c�msor ki�r�s al�.
 - Ahhoz, hogy ism�t helyesen m�k�d� k�dot kapjunk, k�nytelenek vagyunk az eddig bal oldalra ki�rt l�p�s inform�ci�kat megsz�ntetni. Ezt ideiglenesen kivessz�k a k�db�l. Majd a k�s�bbiekben ism�t sz�ks�g lesz r�, kicsit m�dos�tva.
 - H�zunk egy vonalat a disk le�r� r�sz �s a dem� r�sz k�zz�, hogy kicsit elk�l�n�ljenek. A vonalrajzol� r�szt egyenl�re a DrawDisks f�ggv�nybe helyezz�k.  
Ha most lefuttatjuk a k�dot, akkor majdnem j�k vagyunk, lesz�m�tva h�rom apr�s�got. Ezeket a k�vetkez� 3 l�p�sben tessz�k rendbe:
 - Kezdj�k a dem� kezd��llapot�nak felrajzol�s�val. A h�rom r�d �s a korongok felrak�sa kezd� �llapotba r�szt kiemelj�k egy f�ggv�nybe (DrawInitialState) �s megh�vjuk a disk kirajzol� f�ggv�ny ut�n. Ez m�g nem el�g, eddig a kirajzol�s statikus volt, de most k�l�nb�z� m�ret� diskjeink lehetnek, ez�rt ennek a f�ggv�nynek a m�k�d�s�t a megfelel� dinamizmussal l�tjuk el.
 - A m�sodik nagy probl�ma, hogy mivel a l�p�sek ki�r�s�t kiszedt�k, ezzel egy�tt megsz�ntett�k a ResultText v�ltoz� felt�lt�s�t is. A Demo f�ggv�ny viszont sz�m�t erre. Ideiglenesen a Demo f�ggv�nyb�l is kiszedj�k, hogy a program tov�bbra is fusson.
 - A k�vetkez� prob�ma nem is olyan apr�s�g. Mivel a Demo f�ggv�ny rekurz�v, ez�rt 15 korong eset�ben m�r StackOverflowException hib�t kapunk. Ez is egy int� p�lda, hogy rekurzi�val csak �vatosan. Nek�nk itt most meg kell sz�ntetni, teh�t a rekurzi�t �t�rjuk ciklusra. Ezt szerencs�re viszonylag f�jdalom mentesen megtehetj�k. Miut�n mindezzel v�gezt�nk.
Eljutottunk abba az �llapotba, hogy ism�t m�k�dik a kis bemutat�program, de m�g sok minden van h�tra. A k�d m�g mindig nem j� �s a l�p�sek ki�r�sa is megsz�nt. A k�vetkez�kben a l�p�sek sz�m�nak ism�telt ki�r�s�t oldjuk meg.
 - Hogy legyen hova ki�rni, a dem� r�szt kicsit lentebb toljuk, hogy a fenti r�szre legyen hely ki�rni az aktu�lis l�p�st.
 - A rudak f�l� ki�rjuk mindig az aktu�lis l�p�st.
 - A k�vetkez� l�p�s, hogy elind�tjuk a dem�t. 
 - Hogy a programunk ne legyen ennyire statikus, �t�rjuk, hogy a felhaszn�l� adhassa meg a korongok sz�m�t a megadott keretek k�z�tt (SetNumberOfDisks f�ggv�ny). Ezt is kiszervezz�k egy f�ggv�nybe, amit a Main elej�n h�vunk meg. 
M�g mindig vannak probl�m�k, folytassuk a refaktor�l�st:
 - A Main f�ggv�nyt most m�r sz�pen kitiszt�thatjuk. A SetNumberOfDisks h�v�s maradhat a Main elej�n, az InitConsole f�ggv�nyt �s az ut�na k�vetkez� c�m ki�r� r�szt helyezz�k ki egy InitDrawHanoi f�ggv�nybe.
 - A Demo f�ggv�nyt nevezz�k �t RunDemo f�ggv�nyre.
 - Szedj�k ki a f�ggv�ny v�g�r�l a f�l�sleges sort�r�st �s az egykori l�p�seket ki�r� r�szt, amit m�r el�z�leg kiremelt�nk a k�dba, csak m�g bent hagytuk am�g meg nem �rtuk az �j l�p�ski�r�t. Mivel az m�r k�sz erre biztosan nincs sz�ks�g�nk.
 - A Main f�ggv�ny�nk most m�r sz�pen olvashat�. Egyed�l az abc t�mb �rthetetlen ott. Ezt tegy�k �t a RunDemo f�ggv�nybe, �gyis � haszn�lja csak.
 - Van m�g egy olyan hib�nk, hogy ha nagyon kev�s korongot adunk meg, akkor, mivel az ablak ennek f�ggv�ny�ben dinamikus, t�l kicsi lesz �s nem f�r ki a l�p�s ki�r�sa. Ez�rt az oldal minim�lis sz�less�g�t �ll�tsuk be �gy, hogy minden esetben el�g sz�les legyen.
A programunk m�k�dik, a megadott felt�telek mellett, de a k�dunk m�g nem tiszta! A Main sz�p �s olvashat�, ahogy Bob b�csi szertn�, de n�zz�k �t a t�bbi f�ggv�nyt is, mert itt vannak m�g gondok.
 - A SetNumberOfDisks f�ggv�ny szint�n olvashat� �s sz�p, az InitDrawHanoi is, de a DrawDisks f�ggv�nyben megjelentek valami m�gikus sz�mok. Ezeket meg kell sz�ntetni. �gy tudjuk a liter�lokat megsz�ntetni, ha neves�tett konstansokat k�sz�t�nk bel�l�k. Ezzel n�velj�k a k�d olvashat�s�g�t. Az els� ilyen m�gikus r�sz az i*2+1. Ez �gy els�re �rthetetlen. Tanulm�nyozni kell a k�dot, hogy �rthet�v� v�ljon. Ezt nem szabad hagyni, mert az a c�l, hogy a k�d minn�l gyorsabban �s k�nnyebben legyen olvashat�. Mi is ez az i*2+1? Az i*2+1 a mindenkori korong m�rete. �gy hat�roztuk meg a korongok m�ret�t a rajzol�shoz, hogy a korong sorsz�ma hossz� legyen a r�d mindk�t oldal�n, ill. a rudat is eltakarjuk, � a + 1. Teh�t ez egy f�ggv�ny kell legyen. Megadjuk a korong sz�m�t �s adja vissza a korong m�ret�t. L�trehozzuk a GetDiskSize f�ggv�nyt �s mindenhol a k�dban ezt haszn�ljuk fel, ah�nyszor csak egy disk m�ret�t akarjuk meghat�rozni.

Megjegyz�s:
 - L�that�, hogy folyamatos refaktor�l�ssal egy projekt �jra�p�thet�, mik�zben el lehet �rni azt, hogy p�r l�p�senk�nt a program tov�bbra is m�k�d�k�pes �llapotban maradjon. Egy nagy projekt eset�ben ez viszont nem el�g. A refaktor�l�s akkor j�rhat� �t, ha mindig elemi v�ltoztat�sokat hajtunk v�gre. �tnevez�nk egy v�ltoz�t. Kiszervez�nk egy r�szt f�ggv�nybe, majd egy k�vetkez� refaktor�l�sn�l �t�rjuk stb. De m�r az itteni p�ld�n�l is l�that� az, hogy nem minden esetben j�rhat� ez az �t. Ha pedig egyszerre bonyolultabb v�ltoztat�sokat hajtunk v�gre, nem fogjuk tudni, hogy a program m�g az elv�rt �llapotban van-e. Hogy ezen t�llend�lj�nk egy �jfajta refaktor�l�si m�dot kell bevezetni. Ezt majd egy k�vetkez� p�ldaprogramban n�zz�k meg.



Sziasztok!

Kital�ltam egy �j kat�t, amit a megbesz�l�seteken k�sz�lt felv�tel halgat�sa k�zben agyaltam ki. 
Nem tudom keresg�lt-e m�g valaki refaktor�l�s kat�t. Ha kider�lne, hogy nincs ilyen, akkor az fog kider�lni, hogy az EKE Coding Dojo az els� ezen a ter�leten. A kat�kn�l most az SRP elv volt a soros. Itt egy hanoi p�lda kata van, de ez�ttal egy spagetti k�d van megadva, ami sz�pen m�k�dik. A korongok sz�ma egy statikus v�ltoz�ban van, ami m�g a deklar�ci�n�l inicializ�lva van 4-es �rt�kkel (gyakorlatilag �gy ak�r egy konstans is lehetne). A feladat az, hogy ezt dinamikuss� kell tenni. Nagyon egyszer�nek hangzik, hiszen csak meg kell oldani, hogy a v�ltoz�ba egy felhaszn�l�t�l k�rt �rt�ket �rjunk be. De ez egy mocsok spagetti k�d �s ha valaki �t�rja a 4 korongot 5-re vagy nagyobbra, azonnal sz�tesik az eg�sz. 
A spagetti k�d mellett meg van adva egy lehets�ges helyes megold�s, valamint a refaktor�l�s teljes menete is le van �rva.
Mik�zben a refaktor�l�st k�sz�tettem, r�j�ttem, hogy ett�l sokkal t�bb kell. A refaktor�l�s �nmag�ban nem el�g. Az elm�letem, amit a refaktor�l�s k�zben kital�ltam, nagyon egyszer�nek hangzik �s szerintem m�k�dhet. A l�nyege, hogy refaktor�l�s el�tt a refaktor�land� r�szt le kell fedni teszttel. Hogy biztosak legy�nk abban, hogy a refaktor�l�s nem rontott el semmit. Ez lenne a TDR elv, mint Test Driven Refactoring. A k�vetkez� l�p�s az volt, hogy r�kerestem a TDR mozaiksz�ra. Van ilyen t�bb is, de egyik se programoz�ssal kapcsolatos. R�kerestem a test driven refactoring kifejez�sre �s ilyen bizony l�tezik. Ebben nem lesz�nk els�k. Itt egy link: https://stevenschwenke.de/testDrivenRefactoring . Nem kifejezetten spagetti k�dot refaktor�l (�s ez nem is kata, teh�t ott m�g lehet�nk els�k), de gyakorlatilag � is TDR-t val�s�t meg, tudatosan. Sz�val minimum Steven megel�z�tt minket ebben. Itt a l�nyeg: "To guarantee that my refactoring doesn't change the behavior of the code, I create a complete test-coverage in Line of Code (LOC) and of every logical path."
Ett�l f�ggetlen�l, s�t ezzel egy�tt teljes m�rt�kben �n is erre jutottam mint Steven, hogy spagetti k�d refaktor�l�s�t is csak tesztvez�relten c�lszer� megoldani.
A legk�zelebbi kat�n�l megpr�b�lok egy TDR-t megval�s�tani.

�dv,
 Albert