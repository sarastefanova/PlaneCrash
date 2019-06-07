# PlaneCrash

Eдноставна игра во која целта е да се избегнат што повеќе непријателски авиони кои ќе ни се најдат на патот. 

## Почетно мени

![HomePage](https://user-images.githubusercontent.com/37666473/59066995-b099c580-88b0-11e9-98a3-373a22d5fde4.PNG)

Почетното мени се состои од повеќе копчиња, со кликање на првото копче започнува нова игра, но пред да почне нова игра се отвара форма за внес на името и државата на играчот. Потоа следува копче Scores каде што можете да ги видите резултатите од играњето. Доколку сакате да го прочитате упатството за играње кликнете на How to Play и доколку сакате да ја исклучите играта кликнете на Quit Game.

### How to play

![HowToPlay](https://user-images.githubusercontent.com/37666473/59067414-e25f5c00-88b1-11e9-8904-c204d1b279ed.PNG)

Овде е објаснето како се игра играта.

### New Player

![NewPlayer](https://user-images.githubusercontent.com/37666473/59067519-1dfa2600-88b2-11e9-8482-8ae882cf3234.PNG)

Оваа форма се покажува откако ќе претиснете на копчето за нова игра. Во формата се внесуваат името и државата на играчот кој ја игра играта за да може на крајот од играњето да му се пресмета резултатот.

### Scores

![Scores](https://user-images.githubusercontent.com/37666473/59119110-40dc1700-8952-11e9-871d-7c8fe40b7026.PNG)

Во оваа форма се прикажани резултатите на играчите. Првиот играч прикажан во листата има најдобар резултат.

### New Game

![Screenshot (23)](https://user-images.githubusercontent.com/37666473/59119434-18085180-8953-11e9-8c6a-e02a10bb6424.png)

Со кликање на копчето New Game се вклучува нова игра. Главниот авион на почетокот на играта има 3 животи, при секој судир со некој од непријателските авиони животите се намалуваат. Крај на играта е кога главниот авион ги губи сите животи. Животите на авионот се прикажани во горниот лев агол, исто така под нив е прикажано и времето на играње. Во долниот лев агол е поставено копче каде може да се исклучи музиката. Играта може да се пазуира со кликање на копчето P на тастатурата.

## Проектот се состои од 5 форми и 5 класи.

### MainHeroPlane.cs

Со оваа класа е претставен главниот авион. Во неа се чуваат информации за позицијата на авионот, животите на авионот, насоката за движење, неговата висина, ширина и брзина.
Во класата има повеќе методи меѓу кои: Draw(со која се исцртува авионот), Move(за движење на авионот) и ChangeDirection (за промена на насоката на движење). Главниот авион се движи нагоре, надоле, лево и десно. 

### Enemies.cs

Со оваа класа се претставени непријателските авиони. Во класата се чуваат информации за нивната позиција, брзина, ширина,висина и една boolean променлива за тоа дали е удрен авионот од страна на главниот авион. Во класата се наоѓаат методите: Draw(со која се исцртуваат непријателските авиони), Move(за движење на непријателските авиони) и EnemyOnEdge(метод за проверка дали непријателскиот авион излегол надвор од границите на формата).

### Clouds.cs

Со оваа класа се претставени облаците. Во класата имаме информации за позицијата на облакот и неговата брзина. Во класата ги има методите: Draw(со која се исцртуваат облаците), Move(за движење на облаците) и CloudOnEdge(метод за проверка дали облакот излегол надвор од границите на формата).

### Player.cs

Со оваа класа е претставен играчот на играта. Се чуваат информации за името, државата и резултатот на играчот.Во склоп на класата имаме и ToString метода за печатење на инфомрациите на играчот во Scores формата.

### ScoresContainer.cs

Во оваа класа имаме листа од играчи и метод addPlayer со кој ги додаваме играчите во листата. Во класата имаме и метод SortScore со кој правиме сортирање на резултатите на играчите со цел да се прикаже играчот со најдобар резултат(играчот кој ја играл играта најдолго време) прв во листата.

## NewGame.cs - Form 

NewGame класата е класа за главната форма на играта. Во оваа класа се имплементирани следните методи и настани:

* **fillEnemiesList()** - Со овој метод ја пополнуваме листата од непријатели односно користејќи Random ги додаваме непријателските авиони.

* **fillCloudList()** - Со овој метод ги додаваме облаците користејќи Random.

* **MoveEnemies()** - Со овој метод ги придвижуваме непријателските авиони. Притоа проверуваме дали некој од непријателските авиони излегол надвор од границите на формата, и ако излегол го бришеме. Исто така во склоп на овој метод имаме имплементирано бришење на непријателскиот авион ако дојде до судир со главниот авион.

* **MoveClouds()** - Со овој метод ги придвижуваме облаците.Притоа проверуваме дали облаците излегле надвор од границите на формата, и ако излегле ги бришеме. 

* **Crash(Enemies en)** - Метод со кој се проверува дали главниот авион се судрил со непријателскиот авион.

* **calculateTime()** - Метод со кој се пресметува времето на играње во секунди.

* **Serialization()** - Метод со кој се врши серијализација која се користи за зачувување на резултатите на играчите.

* **Deserialization()** - Метод со кој се врши десеријализација на резултатите на играчите.

* **GameOver()** * - Метод за крај на играта. Во овој метод се пресметува времето во секунди, се додава на играчот и се повикува методот за серијализација за да се зачува резултатот.  

* **NewGame_KeyDown** - Настан за контролирање на движењето на главниот авион. Воедно во овој настан е имплементирано исклучување на играта при клик на Escape копчето и пауза на играта на P копчето.

* **Timer1_Tick** - Настан каде се повикуваат методите за движење на облаците и непријателските авиони.

* **TimerGame_Tick** - Настан за одбројување на времето на играње.

* **NewGame_Paint** - Настан за исцртување на главниот авион, непријателските авиони и облаците.


### NewPlayer.cs - Form
Класа која ја претставува формата за играчите.

Класата се состои од следните настани:

* **BtnOK_Click** * - Откако ке се кликне копчето ОК се зачувува играчот и се почнува нова игра.

* **BtnCancel_Click** * - Со кликање на копчеро Cancel се излегува од формата.

* **TxtName_Validating** * - Со овој настан се врши валидација на полето за внес на име на играчот.


### Scores.cs - Form
Класа која ја претставува формата за приказ на резултатите на играчите.
Во оваа форма се чува листа од играчи и нивните резултати. 

Во склоп на формата има имплементација на методот * **Deserialization()** * за десеријализација на резултатите и настанот * **Scores_Load** * каде се повикуваат методот за десеријализација и сортирање на резултатите и се предаваат на листата за да се прикажат.


### HomePage.cs - Form
Класа која ја претставува формата со почетното мени.

Во оваа класа се среќаваат настаните:

* **BtnNewGame_Click** * - Со овој настан е имплименирано кликањето на копчето за нова игра. При клик на копчето New Game се отвара форма за играчот.

* **BtnInstructions_Clicк** * - Со овој настан е имплиментирано кликањето на копчето How To Play. При клик на копчето се отввара нова форма со инструкции за играње.

* **BtnQuit_Click** * - Со овој настан е имплиментирано кликањето на копчето QuitGame.
При клик на копчето се престанува со играње играта.

* **btnScores_Click** * - Со овој настан е импленетирано кликањето на копчето Scores.
При клик на копчето се отвара нова форма со резултати на играчите.

* **HomePage_Activated** * - Со овој настан е имплементиранo свирење на музика во позадина на формата.

* **Button1_Click** * - Со овој настан е имплементирано стопирање и повторно пуштање на музиката.























