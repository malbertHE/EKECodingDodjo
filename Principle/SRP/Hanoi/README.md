SRP (Single Responsibility Principle) - Egy felelõsség egy osztály alapelve

Feladat:
Adott az SRP\Hanoi\Program\MAF.EKE.SRP.HanoiDemo projekt. Ez a projekt egy Hanoi demót valósít meg négy koronggal konzolos felületen. A feladatunk csupán annyi, hogy írjuk át a demót úgy, hogy a felhasználó adhassa meg a korongok számait 1 és 15 között, ahol minden korong színe más, ill. fekete színû nem lehet a korong. Fontos, hogy a konzolon futó demó továbbra is megfelelõen mûködjön (pl. ne essen szét a demó a konzolos ablakon, ne csússzon ki a látható képernyõrõl stb.), bármilyen számot is ad meg a felhasználó a megengedett intervallumban. A feladatunkat nehezíti, hogy ez egy rothadó kód vagy más néven spagetti kód. A kódot a megfelelõ irányba refaktorálással tereljük. Fejlesztés közben tartsuk be a GOF1, GOF2 és SRP elveket.

Ha nem boldogulunk a feladattal, akkor a következõ példát:
 - A Library könyvtár MAF.EKE.SRP.Hanoi projektje a szolgáltatást valósítja meg.
 - A Program könyvtár MAF.EKE.SRP.HanoiDemo2 a konzolos kiírást mutatja be.

A HanoiDemo és HanoiDemo2 konzolos példaprogramokat hasonlítsuk össze, hogy mennyivel lett egyszerûbb.

Mindenkinek jó gyakorlást!


Ha elsõre nem sikerült, ne keseredj el, inkább olvasd el az itteni segítséget, ahol lépésrõl lépésre le van írva a feladat megvalósításának menete.
Mivel a korongok számát egy változó tárolja, ami jelenleg 4-re van állítva, adná magát a lehetõség, hogy írjuk át 5-re. Ez viszont egy rothadó kód, ahogy ezt megpróbálnánk, máris szétcsúszna a konzolos ablak. Azt kell ilyenkor észrevenni, hogy elengedhetetlen a refaktorálás. Ebben a kicsi példában akár azt is megtehetnénk, hogy újraírjuk az egészet, betartva az elveket, de itt most a refaktorálást is szeretnénk gyakorolni. Tehát jöjjön a refaktorálás menete: 
 - Az elsõ lépés, hogy a felületet válasszuk el a logikától. Ha az lett volna a feladat, hogy a felületet cseréljük le grafikus felületre szintén nem tudtuk volna megtenni, mert a felület és a logika egy osztályban van megvalósítva. Mi most készítsünk egy könyvtárt, hogy oda át tudjuk majd tenni a logikát. A fenti megoldott példában ez a MAF.EKE.SRP.Hanoi projekt.
 - Ha elkészítettük a logikát megvalósító projektet, akkor hozzunk létre benne egy Hanoi osztályt.
 - Hozzuk létre a konstruktort, ami 1 paramétert vár, a korongok számát, amit elmentünk egy privát mezõbe, de olvasásra publikussá tesszük (property).
 - Az osztály mûködését többféle képpen megvalósíthatnánk, mi most az egyszerûség kedvéért azt a megoldást válsztjuk, amikor a konstruktor már elõre kiszámolja a lépéseket és eltárolja és a továbbiakban csupán információszolgáltatást nyújt. Szerencsére a programunk nem annyira rotható, a logika nagy részét 2 függvény végzi el, ezeket fogjuk áttenni. Ez a két függvény az eredeti kódban a Hanoi és a HanoiA. Ezeket átemeljük a logikai részbe.
 - A Hanoi függvényt átnevezzük CalcHanoi névre.
 - A függvének ne legyenek statikusak, a static kulcsszót töröljük.
 - A Tuple osztályok használatát meg kell szüntetni. Ez szembe megy a GOF1 alapelvel és Bob bácsi se szereti ha egy változónak a nevébõl nem derül ki, hogy õ mi is pontosan, márpedig a Tuple által egybefogott változókhoz csak típus van megadva vagyis nincs is nevük. Létrehozzuk a Step osztályt, amivel majd kiváltjuk a Tuple osztályt. A Step osztály megvalósítását megtalálod a Step.cs fájlban.
 - A Hanoi.cs fájlban lecseréljük a Tuple osztályt mindenhol Step osztályra.
 - A konstruktorban meghívjuk a CalcHanoi függvényt, de a visszatérési értékét egy privát változóba eltároljuk.
 - A CalcHanoi függvény által kiszámolt és privát változóba mentett listát publikáljuk kifelé a StepList változóban, ami egy IReadOnlyList típusú változó. Ezt is többféleképpen megoldhattuk volna, mi itt most így oldottuk meg azt, hogy a privát listához ne férjenek hozzá, de azért az adatokat le tudják kérdezni.
Remek! Eddig a logikát sikeresen leszakítottuk a felületrõl. Ez volt a könnyebb rész. Mivel a HanoiDemo projektbe itt most nem lehet beleírni, mert ez maga a feladat, ezért létrehoztam egy HanoiDemo2 projektet a Program mappába, amibe átmásoltam a HanoiDemo megvalósítását és így a továbbiakban a HanoiDemo2 kódot refaktoráltam, vagyis a refaktorált felület itt tekinthetõ meg.
Akkor lássuk a további lépéseket:
 - A Hanoi és a HanoiA függvényekre már nincs szükség itt ezért ezekeet töröljük, de ez még nem elég, mert a Main hivatkozott a Hanoi függvényre. A HanoiDemo2 referenciájához hozzáadjuk a MAF.EKE.SRP projektet, majd a Main-beli függvény hivatkozás elõtt létrehozzunk egy Hanoi példányt, valamint a hivatkozást átírjuk, hogy mostmár a Hanoi példánytól vegye az adatokat. Ez még mindig nem elég a ResultList változónk itt még Tuple típusú. Javítjuk mindenhol, hogy Step típusú legyen és a ResultList változót töröljük.
 - Azt találjuk a kódban, hogy az általunk megszûntetett ResultList változót Count értékét is felhasználták. Ezt javíthatnánk úgy, hogy a Hanoi példány LepesekListája változó Count-ját használjuk fel, de ezzel megsértenénk Demeter törvényét, ezért a Hanoi osztályt bõvítjük úgy, hogy legyen LépésekSzáma propertyje, ami ezt az adatot adja vissza.
 - Nagyon jó, hogy elkészítettük a LépésekListája változót a Hanoi osztályban, de valójában ezt az osztályt konténer osztályként kell használjuk, ezért kap egy kis kiegészítést.
 - A programunk ismét teszi a dolgát, csak a logikai részt már kiszerveztük. Viszont a korongok számát még mindig nem lehet növelni. Ehhez további refaktorálás szükséges, melyekbõl most az következik, hogy a Hanoi példányt kitesszük privát osztályszintû változóvá, hogy a többi függvény is elérhesse.
 - Kezdjük el a Main függvény refaktorálását. Elõször is a main elején rakjuk rendbe az ablakot. Töröljük a konzol ablakot, majd írjuk ki, hogy hány korongos Hanoi tornyai demó fut éppen.
 - Kezdenünk kell valamit azzal is, hogy ha futás közben átméretezik az ablakot, akkor szétesik minden. Ez ellen kétféle képen védekezhetünk. Vagy letiltjuk az ablak méretezhetõségét, vagy minden kirajzolásnál a teljes képernyõt újra rajzoljuk. Mindkettõ teljesen más megoldást kínál, mi most a képernyõ méretezésének letiltását választjuk. Ehhez egy kis segítség itt található: https://social.msdn.microsoft.com/Forums/vstudio/en-US/1aa43c6c-71b9-42d4-aa00-60058a85f0eb/c-console-window-disable-resize?forum=csharpgeneral
 - Hogy a kód esztétikumon is javítsunk a korongokSzama változót refaktoráljuk numberOfDisks változóra.
 - A képernyõt átrendezzük. Bal oldalra kirajzoljuk a korongokat. A kirajzoló for ciklust kiszervezzük egy DrawDisks függvénybe és a függvény hívását áthelyezzük közvetlenül a címsor kiírás alá.
 - Ahhoz, hogy ismét helyesen mûködõ kódot kapjunk, kénytelenek vagyunk az eddig bal oldalra kiírt lépés információkat megszüntetni. Ezt ideiglenesen kivesszük a kódból. Majd a késõbbiekben ismét szükség lesz rá, kicsit módosítva.
 - Húzunk egy vonalat a disk leíró rész és a demó rész közzé, hogy kicsit elkülönüljenek. A vonalrajzoló részt egyenlõre a DrawDisks függvénybe helyezzük.  
Ha most lefuttatjuk a kódot, akkor majdnem jók vagyunk, leszámítva három apróságot. Ezeket a következõ 3 lépésben tesszük rendbe:
 - Kezdjük a demó kezdõállapotának felrajzolásával. A három rúd és a korongok felrakása kezdõ állapotba részt kiemeljük egy függvénybe (DrawInitialState) és meghívjuk a disk kirajzoló függvény után. Ez még nem elég, eddig a kirajzolás statikus volt, de most különbözõ méretû diskjeink lehetnek, ezért ennek a függvénynek a mûködését a megfelelõ dinamizmussal látjuk el.
 - A második nagy probléma, hogy mivel a lépések kiírását kiszedtük, ezzel együtt megszûntettük a ResultText változó feltöltését is. A Demo függvény viszont számít erre. Ideiglenesen a Demo függvénybõl is kiszedjük, hogy a program továbbra is fusson.
 - A következõ probéma nem is olyan apróság. Mivel a Demo függvény rekurzív, ezért 15 korong esetében már StackOverflowException hibát kapunk. Ez is egy intõ példa, hogy rekurzióval csak óvatosan. Nekünk itt most meg kell szüntetni, tehát a rekurziót átírjuk ciklusra. Ezt szerencsére viszonylag fájdalom mentesen megtehetjük. Miután mindezzel végeztünk.
Eljutottunk abba az állapotba, hogy ismét mûködik a kis bemutatóprogram, de még sok minden van hátra. A kód még mindig nem jó és a lépések kiírása is megszûnt. A következõkben a lépések számának ismételt kiírását oldjuk meg.
 - Hogy legyen hova kiírni, a demó részt kicsit lentebb toljuk, hogy a fenti részre legyen hely kiírni az aktuális lépést.
 - A rudak fölé kiírjuk mindig az aktuális lépést.
 - A következõ lépés, hogy elindítjuk a demót. 
 - Hogy a programunk ne legyen ennyire statikus, átírjuk, hogy a felhasználó adhassa meg a korongok számát a megadott keretek között (SetNumberOfDisks függvény). Ezt is kiszervezzük egy függvénybe, amit a Main elején hívunk meg. 
Még mindig vannak problémák, folytassuk a refaktorálást:
 - A Main függvényt most már szépen kitisztíthatjuk. A SetNumberOfDisks hívás maradhat a Main elején, az InitConsole függvényt és az utána következõ cím kiíró részt helyezzük ki egy InitDrawHanoi függvénybe.
 - A Demo függvényt nevezzük át RunDemo függvényre.
 - Szedjük ki a függvény végérõl a fölösleges sortörést és az egykori lépéseket kiíró részt, amit már elõzõleg kiremeltünk a kódba, csak még bent hagytuk amíg meg nem írtuk az új lépéskiírót. Mivel az már kész erre biztosan nincs szükségünk.
 - A Main függvényünk most már szépen olvasható. Egyedül az abc tömb érthetetlen ott. Ezt tegyük át a RunDemo függvénybe, úgyis õ használja csak.
 - Van még egy olyan hibánk, hogy ha nagyon kevés korongot adunk meg, akkor, mivel az ablak ennek függvényében dinamikus, túl kicsi lesz és nem fér ki a lépés kiírása. Ezért az oldal minimális szélességét állítsuk be úgy, hogy minden esetben elég széles legyen.
A programunk mûködik, a megadott feltételek mellett, de a kódunk még nem tiszta! A Main szép és olvasható, ahogy Bob bácsi szertné, de nézzük át a többi függvényt is, mert itt vannak még gondok.
 - A SetNumberOfDisks függvény szintén olvasható és szép, az InitDrawHanoi is, de a DrawDisks függvényben megjelentek valami mágikus számok. Ezeket meg kell szüntetni. Úgy tudjuk a literálokat megszüntetni, ha nevesített konstansokat készítünk belõlük. Ezzel növeljük a kód olvashatóságát. Az elsõ ilyen mágikus rész az i*2+1. Ez így elsõre érthetetlen. Tanulmányozni kell a kódot, hogy érthetõvé váljon. Ezt nem szabad hagyni, mert az a cél, hogy a kód minnél gyorsabban és könnyebben legyen olvasható. Mi is ez az i*2+1? Az i*2+1 a mindenkori korong mérete. Úgy határoztuk meg a korongok méretét a rajzoláshoz, hogy a korong sorszáma hosszú legyen a rúd mindkét oldalán, ill. a rudat is eltakarjuk, õ a + 1. Tehát ez egy függvény kell legyen. Megadjuk a korong számát és adja vissza a korong méretét. Létrehozzuk a GetDiskSize függvényt és mindenhol a kódban ezt használjuk fel, ahányszor csak egy disk méretét akarjuk meghatározni.

Megjegyzés:
 - Látható, hogy folyamatos refaktorálással egy projekt újraépíthetõ, miközben el lehet érni azt, hogy pár lépésenként a program továbbra is mûködõképes állapotban maradjon. Egy nagy projekt esetében ez viszont nem elég. A refaktorálás akkor járható út, ha mindig elemi változtatásokat hajtunk végre. Átnevezünk egy változót. Kiszervezünk egy részt függvénybe, majd egy következõ refaktorálásnál átírjuk stb. De már az itteni példánál is látható az, hogy nem minden esetben járható ez az út. Ha pedig egyszerre bonyolultabb változtatásokat hajtunk végre, nem fogjuk tudni, hogy a program még az elvárt állapotban van-e. Hogy ezen túllendüljünk egy újfajta refaktorálási módot kell bevezetni. Ezt majd egy következõ példaprogramban nézzük meg.



Sziasztok!

Kitaláltam egy új katát, amit a megbeszéléseteken készült felvétel halgatása közben agyaltam ki. 
Nem tudom keresgélt-e még valaki refaktorálós katát. Ha kiderülne, hogy nincs ilyen, akkor az fog kiderülni, hogy az EKE Coding Dojo az elsõ ezen a területen. A katáknál most az SRP elv volt a soros. Itt egy hanoi példa kata van, de ezúttal egy spagetti kód van megadva, ami szépen mûködik. A korongok száma egy statikus változóban van, ami még a deklarációnál inicializálva van 4-es értékkel (gyakorlatilag így akár egy konstans is lehetne). A feladat az, hogy ezt dinamikussá kell tenni. Nagyon egyszerûnek hangzik, hiszen csak meg kell oldani, hogy a változóba egy felhasználótól kért értéket írjunk be. De ez egy mocsok spagetti kód és ha valaki átírja a 4 korongot 5-re vagy nagyobbra, azonnal szétesik az egész. 
A spagetti kód mellett meg van adva egy lehetséges helyes megoldás, valamint a refaktorálás teljes menete is le van írva.
Miközben a refaktorálást készítettem, rájöttem, hogy ettõl sokkal több kell. A refaktorálás önmagában nem elég. Az elméletem, amit a refaktorálás közben kitaláltam, nagyon egyszerûnek hangzik és szerintem mûködhet. A lényege, hogy refaktorálás elõtt a refaktorálandó részt le kell fedni teszttel. Hogy biztosak legyünk abban, hogy a refaktorálás nem rontott el semmit. Ez lenne a TDR elv, mint Test Driven Refactoring. A következõ lépés az volt, hogy rákerestem a TDR mozaikszóra. Van ilyen több is, de egyik se programozással kapcsolatos. Rákerestem a test driven refactoring kifejezésre és ilyen bizony létezik. Ebben nem leszünk elsõk. Itt egy link: https://stevenschwenke.de/testDrivenRefactoring . Nem kifejezetten spagetti kódot refaktorál (és ez nem is kata, tehát ott még lehetünk elsõk), de gyakorlatilag õ is TDR-t valósít meg, tudatosan. Szóval minimum Steven megelõzött minket ebben. Itt a lényeg: "To guarantee that my refactoring doesn't change the behavior of the code, I create a complete test-coverage in Line of Code (LOC) and of every logical path."
Ettõl függetlenül, sõt ezzel együtt teljes mértékben én is erre jutottam mint Steven, hogy spagetti kód refaktorálását is csak tesztvezérelten célszerû megoldani.
A legközelebbi katánál megpróbálok egy TDR-t megvalósítani.

Üdv,
 Albert