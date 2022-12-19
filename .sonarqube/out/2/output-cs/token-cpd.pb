�<
fC:\Users\Ovidiu\source\repos\MyDocAppointmentRight\MyDocAppointment.Application\AppointmentsService.cs
	namespace 	
MyDocAppointment
 
. 
Application &
{ 
public		 

class		 
AppointmentsService		 $
:		% & 
IAppointmentsService		' ;
{

 
private 
readonly #
IAppointmentsRepository 0#
_appointmentsRepository1 H
;H I
public 
AppointmentsService "
(" ##
IAppointmentsRepository# :"
appointmentsRepository; Q
)Q R
{
_appointmentsRepository #
=$ %"
appointmentsRepository& <
;< =
} 	
public 
async 
Task 
Create  
(  !
Appointment! ,
appointment- 8
)8 9
{ 	
appointment 
. 
Id 
= 
Guid  
.  !
NewGuid! (
(( )
)) *
;* +
appointment 
. 
Payment 
=  !
new" %
Payment& -
(- .
). /
;/ 0
appointment 
. 
Payment 
.  
Id  "
=# $
Guid% )
.) *
NewGuid* 1
(1 2
)2 3
;3 4
appointment 
. 
Payment 
.  
DueDate  '
=( )
DateTime* 2
.2 3
Now3 6
;6 7
appointment 
. 
Payment 
.  

=. /
DateTime0 8
.8 9
Now9 <
;< =
appointment 
. 
Payment 
.  
EmissionDate  ,
=- .
DateTime/ 7
.7 8
Now8 ;
;; <
await #
_appointmentsRepository )
.) *
Create* 0
(0 1
appointment1 <
)< =
;= >
} 	
public 
async 
Task 
< 
Result  
>  !
Delete" (
(( )
Guid) -
id. 0
)0 1
{ 	
Appointment 
appointment #
=$ %
await& +#
_appointmentsRepository, C
.C D
GetByIdD K
(K L
idL N
)N O
;O P
if   
(   
appointment   
==   
null   "
)  " #
{!! 
return"" 
Result"" 
."" 
Failure"" %
(""% &
$"""& (
$str""( <
{""< =
id""= ?
}""? @
$str""@ K
"""K L
)""L M
;""M N
}## 
await$$ #
_appointmentsRepository$$ )
.$$) *
Delete$$* 0
($$0 1
appointment$$1 <
)$$< =
;$$= >
return%% 
Result%% 
.%% 
Success%% !
(%%! "
)%%" #
;%%# $
}&& 	
public(( 
async(( 
Task(( 
<(( 
Result((  
<((  !
IEnumerable((! ,
<((, -
Appointment((- 8
>((8 9
>((9 :
>((: ;
GetAll((< B
(((B C
)((C D
{)) 	
var** 
appointments** 
=** 
await** $#
_appointmentsRepository**% <
.**< =
GetAll**= C
(**C D
)**D E
;**E F
if++ 
(++ 
!++ 
appointments++ 
.++ 
Any++ !
(++! "
)++" #
)++# $
{,, 
return-- 
Result-- 
<-- 
IEnumerable-- )
<--) *
Appointment--* 5
>--5 6
>--6 7
.--7 8
Failure--8 ?
(--? @
$"--@ B
$str--B X
"--X Y
)--Y Z
;--Z [
}.. 
return// 
Result// 
<// 
IEnumerable// %
<//% &
Appointment//& 1
>//1 2
>//2 3
.//3 4
Success//4 ;
(//; <
appointments//< H
)//H I
;//I J
}00 	
public22 
async22 
Task22 
<22 
Result22  
<22  !
Appointment22! ,
>22, -
>22- .
GetById22/ 6
(226 7
Guid227 ;
id22< >
)22> ?
{33 	
var44 
appointment44 
=44 
await44 ##
_appointmentsRepository44$ ;
.44; <
GetById44< C
(44C D
id44D F
)44F G
;44G H
if55 
(55 
appointment55 
==55 
null55 "
)55" #
{66 
return77 
Result77 
<77 
Appointment77 )
>77) *
.77* +
Failure77+ 2
(772 3
$"773 5
$str775 J
{77J K
id77K M
}77M N
$str77N ^
"77^ _
)77_ `
;77` a
}88 
return99 
Result99 
<99 
Appointment99 %
>99% &
.99& '
Success99' .
(99. /
appointment99/ :
)99: ;
;99; <
}:: 	
public<< 
async<< 
Task<< 
SaveChanges<< %
(<<% &
)<<& '
{== 	
await>> #
_appointmentsRepository>> )
.>>) *
SaveChanges>>* 5
(>>5 6
)>>6 7
;>>7 8
}?? 	
publicAA 
asyncAA 
TaskAA 
<AA 
ResultAA  
<AA  !
AppointmentAA! ,
>AA, -
>AA- .
UpdateAA/ 5
(AA5 6
AppointmentAA6 A
appointmentAAB M
,AAM N
GuidAAO S
idAAT V
)AAV W
{BB 	
varCC 
currentAppointmentCC "
=CC# $
awaitCC% *#
_appointmentsRepositoryCC+ B
.CCB C
GetByIdCCC J
(CCJ K
idCCK M
)CCM N
;CCN O
ifDD 
(DD 
currentAppointmentDD "
==DD# %
nullDD& *
)DD* +
{EE 
returnFF 
ResultFF 
<FF 
AppointmentFF )
>FF) *
.FF* +
FailureFF+ 2
(FF2 3
$"FF3 5
$strFF5 J
{FFJ K
idFFK M
}FFM N
$strFFN ^
"FF^ _
)FF_ `
;FF` a
}HH 
currentAppointmentJJ 
.JJ 
LocationJJ '
=JJ( )
appointmentJJ* 5
.JJ5 6
LocationJJ6 >
;JJ> ?
currentAppointmentKK 
.KK 
SpecializationKK -
=KK. /
appointmentKK0 ;
.KK; <
SpecializationKK< J
;KKJ K
currentAppointmentLL 
.LL 
AppointmentTimeLL .
=LL/ 0
appointmentLL1 <
.LL< =
AppointmentTimeLL= L
;LLL M
awaitNN #
_appointmentsRepositoryNN )
.NN) *
SaveChangesNN* 5
(NN5 6
)NN6 7
;NN7 8
returnPP 
ResultPP 
<PP 
AppointmentPP %
>PP% &
.PP& '
SuccessPP' .
(PP. /
currentAppointmentPP/ A
)PPA B
;PPB C
}QQ 	
}RR 
}SS �8
`C:\Users\Ovidiu\source\repos\MyDocAppointmentRight\MyDocAppointment.Application\DoctorService.cs
	namespace 	
MyDocAppointment
 
. 
Application &
{ 
public 

class 
DoctorsService 
:  !
IDoctorsService" 1
{		 
private

 
readonly

 
IDoctorsRepository

 +
_doctorsRepository

, >
;

> ?
public 
DoctorsService 
( 
IDoctorsRepository 0
doctorsRepository1 B
)B C
{ 	
_doctorsRepository
=
doctorsRepository
;
} 	
public 
async 
Task 
Create  
(  !
Doctor! '
doctor( .
). /
{ 	
await 
_doctorsRepository $
.$ %
Create% +
(+ ,
doctor, 2
)2 3
;3 4
} 	
public 
async 
Task 
< 
Result  
>  !
Delete" (
(( )
Guid) -
id. 0
)0 1
{ 	
Doctor 
doctor 
= 
await !
_doctorsRepository" 4
.4 5
GetById5 <
(< =
id= ?
)? @
;@ A
if 
( 
doctor 
== 
null 
) 
{ 
return 
Result 
. 
Failure %
(% &
$"& (
$str( 7
{7 8
id8 :
}: ;
$str; F
"F G
)G H
;H I
} 
await 
_doctorsRepository $
.$ %
Delete% +
(+ ,
doctor, 2
)2 3
;3 4
return 
Result 
. 
Success !
(! "
)" #
;# $
} 	
public   
async   
Task   
<   
Result    
<    !
IEnumerable  ! ,
<  , -
Doctor  - 3
>  3 4
>  4 5
>  5 6
GetAll  7 =
(  = >
)  > ?
{!! 	
var"" 
doctors"" 
="" 
await"" 
_doctorsRepository""  2
.""2 3
GetAll""3 9
(""9 :
)"": ;
;""; <
if## 
(## 
!## 
doctors## 
.## 
Any## 
(## 
)## 
)## 
{$$ 
return%% 
Result%% 
<%% 
IEnumerable%% )
<%%) *
Doctor%%* 0
>%%0 1
>%%1 2
.%%2 3
Failure%%3 :
(%%: ;
$"%%; =
$str%%= N
"%%N O
)%%O P
;%%P Q
}&& 
return'' 
Result'' 
<'' 
IEnumerable'' %
<''% &
Doctor''& ,
>'', -
>''- .
.''. /
Success''/ 6
(''6 7
doctors''7 >
)''> ?
;''? @
}(( 	
public** 
async** 
Task** 
<** 
Result**  
<**  !
Doctor**! '
>**' (
>**( )
GetById*** 1
(**1 2
Guid**2 6
id**7 9
)**9 :
{++ 	
var,, 
doctor,, 
=,, 
await,, 
_doctorsRepository,, 1
.,,1 2
GetById,,2 9
(,,9 :
id,,: <
),,< =
;,,= >
if-- 
(-- 
doctor-- 
==-- 
null-- 
)-- 
{.. 
return// 
Result// 
<// 
Doctor// $
>//$ %
.//% &
Failure//& -
(//- .
$"//. 0
$str//0 @
{//@ A
id//A C
}//C D
$str//D T
"//T U
)//U V
;//V W
}00 
return11 
Result11 
<11 
Doctor11  
>11  !
.11! "
Success11" )
(11) *
doctor11* 0
)110 1
;111 2
}22 	
public44 
async44 
Task44 
SaveChanges44 %
(44% &
)44& '
{55 	
await66 
_doctorsRepository66 $
.66$ %
SaveChanges66% 0
(660 1
)661 2
;662 3
}77 	
public99 
async99 
Task99 
<99 
Result99  
<99  !
Doctor99! '
>99' (
>99( )
Update99* 0
(990 1
Doctor991 7
doctor998 >
,99> ?
Guid99@ D
doctorId99E M
)99M N
{:: 	
var;; 

=;; 
await;;  %
_doctorsRepository;;& 8
.;;8 9
GetById;;9 @
(;;@ A
doctorId;;A I
);;I J
;;;J K
if<< 
(<< 

==<<  
null<<! %
)<<% &
{== 
return>> 
Result>> 
<>> 
Doctor>> $
>>>$ %
.>>% &
Failure>>& -
(>>- .
$">>. 0
$str>>0 @
{>>@ A
doctorId>>A I
}>>I J
$str>>J Z
">>Z [
)>>[ \
;>>\ ]
}@@ 

.BB 
NameBB 
=BB  
doctorBB! '
.BB' (
NameBB( ,
;BB, -

.CC 
SurnameCC !
=CC" #
doctorCC$ *
.CC* +
SurnameCC+ 2
;CC2 3

.DD 
AgeDD 
=DD 
doctorDD  &
.DD& '
AgeDD' *
;DD* +

.EE 
GenderEE  
=EE! "
doctorEE# )
.EE) *
GenderEE* 0
;EE0 1

.FF 
EmailAddressFF &
=FF' (
doctorFF) /
.FF/ 0
EmailAddressFF0 <
;FF< =

.GG 
PhoneNumberGG %
=GG& '
doctorGG( .
.GG. /
PhoneNumberGG/ :
;GG: ;

.HH 
HomeAddressHH %
=HH& '
doctorHH( .
.HH. /
HomeAddressHH/ :
;HH: ;

.II 

SpecialityII $
=II% &
doctorII' -
.II- .

SpecialityII. 8
;II8 9
awaitKK 
_doctorsRepositoryKK $
.KK$ %
SaveChangesKK% 0
(KK0 1
)KK1 2
;KK2 3
returnMM 
ResultMM 
<MM 
DoctorMM  
>MM  !
.MM! "
SuccessMM" )
(MM) *

)MM7 8
;MM8 9
}NN 	
}OO 
}PP �2
_C:\Users\Ovidiu\source\repos\MyDocAppointmentRight\MyDocAppointment.Application\DrugsService.cs
	namespace 	
MyDocAppointment
 
. 
Application &
{ 
public 

class 
DrugsService 
: 

{		 
private

 
readonly

 
IDrugsRepository

 )
_drugsRepository

* :
;

: ;
public 
DrugsService 
( 
IDrugsRepository ,
drugsRepository- <
)< =
{ 	
_drugsRepository
=
drugsRepository
;
} 	
public 
async 
Task 
Create  
(  !
Drug! %
drug& *
)* +
{ 	
await 
_drugsRepository "
." #
Create# )
() *
drug* .
). /
;/ 0
} 	
public 
async 
Task 
< 
Result  
>  !
Delete" (
(( )
Guid) -
id. 0
)0 1
{ 	
var 
drug 
= 
await 
_drugsRepository -
.- .
GetById. 5
(5 6
id6 8
)8 9
;9 :
if 
( 
drug 
== 
null 
) 
{ 
return 
Result 
. 
Failure %
(% &
$"& (
$str( 5
{5 6
id6 8
}8 9
$str9 D
"D E
)E F
;F G
} 
await 
_drugsRepository "
." #
Delete# )
() *
drug* .
). /
;/ 0
return 
Result 
. 
Success !
(! "
)" #
;# $
} 	
public   
async   
Task   
<   
Result    
<    !
IEnumerable  ! ,
<  , -
Drug  - 1
>  1 2
>  2 3
>  3 4
GetAll  5 ;
(  ; <
)  < =
{!! 	
var"" 
drugs"" 
="" 
await"" 
_drugsRepository"" .
."". /
GetAll""/ 5
(""5 6
)""6 7
;""7 8
if## 
(## 
!## 
drugs## 
.## 
Any## 
(## 
)## 
)## 
{$$ 
return%% 
Result%% 
<%% 
IEnumerable%% )
<%%) *
Drug%%* .
>%%. /
>%%/ 0
.%%0 1
Failure%%1 8
(%%8 9
$"%%9 ;
$str%%; J
"%%J K
)%%K L
;%%L M
}&& 
return'' 
Result'' 
<'' 
IEnumerable'' %
<''% &
Drug''& *
>''* +
>''+ ,
.'', -
Success''- 4
(''4 5
drugs''5 :
)'': ;
;''; <
}(( 	
public** 
async** 
Task** 
<** 
Result**  
<**  !
Drug**! %
>**% &
>**& '
GetById**( /
(**/ 0
Guid**0 4
id**5 7
)**7 8
{++ 	
var,, 
drug,, 
=,, 
await,, 
_drugsRepository,, -
.,,- .
GetById,,. 5
(,,5 6
id,,6 8
),,8 9
;,,9 :
if-- 
(-- 
drug-- 
==-- 
null-- 
)-- 
{.. 
return// 
Result// 
<// 
Drug// "
>//" #
.//# $
Failure//$ +
(//+ ,
$"//, .
$str//. <
{//< =
id//= ?
}//? @
$str//@ P
"//P Q
)//Q R
;//R S
}00 
return11 
Result11 
<11 
Drug11 
>11 
.11  
Success11  '
(11' (
drug11( ,
)11, -
;11- .
}22 	
public44 
async44 
Task44 
SaveChanges44 %
(44% &
)44& '
{55 	
await66 
_drugsRepository66 "
.66" #
SaveChanges66# .
(66. /
)66/ 0
;660 1
}77 	
public99 
async99 
Task99 
<99 
Result99  
<99  !
Drug99! %
>99% &
>99& '
Update99( .
(99. /
Drug99/ 3
drug994 8
,998 9
Guid99: >
drugId99? E
)99E F
{:: 	
var;; 
currentDrug;; 
=;; 
await;; #
_drugsRepository;;$ 4
.;;4 5
GetById;;5 <
(;;< =
drugId;;= C
);;C D
;;;D E
if<< 
(<< 
currentDrug<< 
==<< 
null<< #
)<<# $
{== 
return>> 
Result>> 
<>> 
Drug>> "
>>>" #
.>># $
Failure>>$ +
(>>+ ,
$">>, .
$str>>. <
{>>< =
drugId>>= C
}>>C D
$str>>D T
">>T U
)>>U V
;>>V W
}@@ 
currentDrugBB 
.BB 
NameBB 
=BB 
drugBB #
.BB# $
NameBB$ (
;BB( )
currentDrugCC 
.CC 
VendorCC 
=CC  
drugCC! %
.CC% &
VendorCC& ,
;CC, -
currentDrugDD 
.DD 
CategoryDD  
=DD! "
drugDD# '
.DD' (
CategoryDD( 0
;DD0 1
currentDrugEE 
.EE 
PriceEE 
=EE 
drugEE  $
.EE$ %
PriceEE% *
;EE* +
awaitGG 
_drugsRepositoryGG "
.GG" #
SaveChangesGG# .
(GG. /
)GG/ 0
;GG0 1
returnII 
ResultII 
<II 
DrugII 
>II 
.II  
SuccessII  '
(II' (
currentDrugII( 3
)II3 4
;II4 5
}JJ 	
}KK 
}LL �7
bC:\Users\Ovidiu\source\repos\MyDocAppointmentRight\MyDocAppointment.Application\PatientsService.cs
	namespace 	
MyDocAppointment
 
. 
Application &
{ 
public 

class 
PatientsService  
:! "
IPatientsService# 3
{ 
private		 
readonly		 
IPatientsRepository		 ,
_patientsRepository		- @
;		@ A
public

 
PatientsService

 
(

 
IPatientsRepository

 2
patientsRepository

3 E
)

E F
{ 	
_patientsRepository 
=  !
patientsRepository" 4
;4 5
}
public 
async 
Task 
Create  
(  !
Patient! (
patient) 0
)0 1
{ 	
await 
_patientsRepository %
.% &
Create& ,
(, -
patient- 4
)4 5
;5 6
} 	
public 
async 
Task 
< 
Result  
>  !
Delete" (
(( )
Guid) -
id. 0
)0 1
{ 	
var 
patient 
= 
await 
_patientsRepository  3
.3 4
GetById4 ;
(; <
id< >
)> ?
;? @
if 
( 
patient 
== 
null 
)  
{ 
return 
Result 
. 
Failure %
(% &
$"& (
$str( 9
{9 :
id: <
}< =
$str= M
"M N
)N O
;O P
} 
await 
_patientsRepository %
.% &
Delete& ,
(, -
patient- 4
)4 5
;5 6
return 
Result 
. 
Success !
(! "
)" #
;# $
} 	
public 
async 
Task 
< 
Result  
<  !
IEnumerable! ,
<, -
Patient- 4
>4 5
>5 6
>6 7
GetAll8 >
(> ?
)? @
{   	
var!! 
patients!! 
=!! 
await!!  
_patientsRepository!!! 4
.!!4 5
GetAll!!5 ;
(!!; <
)!!< =
;!!= >
if"" 
("" 
!"" 
patients"" 
."" 
Any"" 
("" 
)"" 
)""  
{## 
return$$ 
Result$$ 
<$$ 
IEnumerable$$ )
<$$) *
Patient$$* 1
>$$1 2
>$$2 3
.$$3 4
Failure$$4 ;
($$; <
$"$$< >
$str$$> N
"$$N O
)$$O P
;$$P Q
}%% 
return&& 
Result&& 
<&& 
IEnumerable&& %
<&&% &
Patient&&& -
>&&- .
>&&. /
.&&/ 0
Success&&0 7
(&&7 8
patients&&8 @
)&&@ A
;&&A B
}'' 	
public)) 
async)) 
Task)) 
<)) 
Result))  
<))  !
Patient))! (
>))( )
>))) *
GetById))+ 2
())2 3
Guid))3 7
id))8 :
))): ;
{** 	
var++ 
patient++ 
=++ 
await++ 
_patientsRepository++  3
.++3 4
GetById++4 ;
(++; <
id++< >
)++> ?
;++? @
if,, 
(,, 
patient,, 
==,, 
null,, 
),, 
{-- 
return.. 
Result.. 
<.. 
Patient.. %
>..% &
...& '
Failure..' .
(... /
$"../ 1
$str..1 B
{..B C
id..C E
}..E F
$str..F V
"..V W
)..W X
;..X Y
}// 
return00 
Result00 
<00 
Patient00 !
>00! "
.00" #
Success00# *
(00* +
patient00+ 2
)002 3
;003 4
}11 	
public33 
async33 
Task33 
SaveChanges33 %
(33% &
)33& '
{44 	
await55 
_patientsRepository55 %
.55% &
SaveChanges55& 1
(551 2
)552 3
;553 4
}66 	
public88 
async88 
Task88 
<88 
Result88  
<88  !
Patient88! (
>88( )
>88) *
Update88+ 1
(881 2
Patient882 9
patient88: A
,88A B
Guid88C G
	patientId88H Q
)88Q R
{99 	
var:: 
currentPatient:: 
=::  
await::! &
_patientsRepository::' :
.::: ;
GetById::; B
(::B C
	patientId::C L
)::L M
;::M N
if;; 
(;; 
currentPatient;; 
==;; !
null;;" &
);;& '
{<< 
return== 
Result== 
<== 
Patient== %
>==% &
.==& '
Failure==' .
(==. /
$"==/ 1
$str==1 B
{==B C
	patientId==C L
}==L M
$str==M ]
"==] ^
)==^ _
;==_ `
}>> 
currentPatient@@ 
.@@ 
Name@@ 
=@@  !
patient@@" )
.@@) *
Name@@* .
;@@. /
currentPatientAA 
.AA 
SurnameAA "
=AA# $
patientAA% ,
.AA, -
SurnameAA- 4
;AA4 5
currentPatientBB 
.BB 
AgeBB 
=BB  
patientBB! (
.BB( )
AgeBB) ,
;BB, -
currentPatientCC 
.CC 
GenderCC !
=CC" #
patientCC$ +
.CC+ ,
GenderCC, 2
;CC2 3
currentPatientDD 
.DD 
EmailAddressDD '
=DD( )
patientDD* 1
.DD1 2
EmailAddressDD2 >
;DD> ?
currentPatientEE 
.EE 
PhoneNumberEE &
=EE' (
patientEE) 0
.EE0 1
PhoneNumberEE1 <
;EE< =
currentPatientFF 
.FF 
HomeAddressFF &
=FF' (
patientFF) 0
.FF0 1
HomeAddressFF1 <
;FF< =
awaitHH 
_patientsRepositoryHH %
.HH% &
SaveChangesHH& 1
(HH1 2
)HH2 3
;HH3 4
returnJJ 
ResultJJ 
<JJ 
PatientJJ !
>JJ! "
.JJ" #
SuccessJJ# *
(JJ* +
currentPatientJJ+ 9
)JJ9 :
;JJ: ;
}KK 	
}LL 
}MM 