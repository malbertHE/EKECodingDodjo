# OCP (Open-Closed Principle) - Nyitva-zárt alapelv

> Feladat: Adott az [OCP\Shapes\Program\MAF.EKE.OCP.ShapesDemo](https://github.com/malbertHE/EKECodingDodjo/tree/master/Principle/OCP/Shapes/Program/MAF.EKE.OCP.ShapesDemo) projekt. Ez egy konzolos alkalmazást valósít meg, ami egy megadott méretű négyzetlap területét számolja ki. Két feladatot kell megoldani. Az első, hogy ne csak négyzet, hanem téglalap területét is tudja kiszámolni. A második, hogy cseréljük le a felületet egy WinForm felületre és ne csak kiszámoljuk, hanem rajzoljuk is ki egy megadott koordinátára az adott alakzatot. Tartsuk be a már eddig begyakorolt elveket, valamint az OCP elvet. Fontos, hogy az eredeti kódot továbbfejlesztve, tesztvezérelten érjünk célba, hogy egyúttal gyakoroljuk a TDR fejlesztési módszert. Ez a módszer segítséget jelent régi rossz kódok rendberakásánál, úgy, hogy közben a kód minden egyes refaktorálás után működőképes marad.

Ha nem boldogulunk a feladattal, akkor nézzük át az elkészített páldák forrásait:
- A Library könyvtár [MAF.EKE.OCP.Shapes](https://github.com/malbertHE/EKECodingDodjo/tree/master/Principle/OCP/Shapes/Library/MAF.EKE.OCP.Shapes) projektje a logikai részt valósítja meg.
- A Library könyvtár [MAF.EKE.OCP.Shapes.Test](https://github.com/malbertHE/EKECodingDodjo/tree/master/Principle/OCP/Shapes/Library/MAF.EKE.OCP.Shapes.Test) projektje a logikai rész tesztelését valósítja meg.
- A Program könyvtár [OCP\Shapes\Program\MAF.EKE.OCP.ShapesDemo2](https://github.com/malbertHE/EKECodingDodjo/tree/master/Principle/OCP/Shapes/Program/MAF.EKE.OCP.ShapesDemo2) projektje a feladatot kielégítő projekt.

Ha elsőre nem sikerült, ne keseredj el, inkább olvasd el a [Description.md](Docs/Description.md) fájlban leírt segítséget, ahol lépésről lépésre le van írva a feladat megvalósításának menete.

**Mindenkinek jó gyakorlást!**
