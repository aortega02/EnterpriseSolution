using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnterpriseSolution
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    static class VarConst
    {

        //#####  CONSTANTES UTILIZADAS EN EL SISTEMA  #####

        public static string CodEmpresa;    //###  GUARDA EL CODIGO DE LA EMPRESA DONDE SE EJECUTA LA APLICACION  ###
        public static string CodEmpleado;   //###  GUARDA EL CODIGO DEL EMPLEADO SELECCIONADO EN EL FORMULARIO EMPLEADOS  ###
        public static string Empresa;       //###  GUARDA EL NOMBRE DE LA EMPRESA QUE EJECUTA LA APLICACION  ###
        public static string Rif;           //###  GUARDA EL RIF DE LA EMPRESA QUE EJECUTA LA APLICACION  ###
        public static string CierreFis;     //###  GUARDA EL CIERRE FISCAL DE LA EMPRESA  ###
        public static string Usuario;       //###  GUARDA EL USUARIO QUE ESTA EJECUTANDO LA APLICACION  ###
        public static string Empleado;      //###  GUARDA EL NOMBRE COMPLETO DEL USUARIO DE LA APLICACION  ###
        public static string Perfil;        //###  GUARDA EL PERFIL DEL USUARIO EN LA EMPRESA ACTUAL  ###
        public static string Auditor;       //###  GUARDA EL REGISTRO PARA AUDITORIA DEL SISTEMA  ###
        public static int NumEmpresas;      //###  GUARDA EL NUMERO DE EMPRESAS REGISTRADAS EN BASE DE DATOS  ###
        public static bool BanError = false;//###  GUARDA UN AVISO PARA PASAR PARAMETROS DE CONFIGURACION  ###
        public static string NomSkin = "";  //###  GUARDA EL NOMBRE DEL SKIN ACTUAL  ###
        public static string NumEmp = "0";  //###  NUMERO DE EMPLEADOS VALIDOS POR EMPRESA  ###
        public static string NumTra = "0";  //###  NUMERO DE EMPRESAS VALIDAS EN EL SISTEMA  ###
        public static bool BanAct = true;   //###  VALOR DEL BOTON DE ACTUALIZACION DEPENDIENDO DE EL TIPO DE LICENCIA  ###
        public static string WebAct = "http://www.juris-line.com.ve/imagenes/Update/"; //###  GUARDA LA PAGINA POR DEFECTO PARA LA ACTUALIZACION  ###
        public static string rpt = "";      //###  GUARDA EL NOMBRE DEL REPORTE QUE SERÁ LLAMADO EN EL FORMULARIO (FrmReportes)  ###


        //#####  CONSTANTES UTILIZADAS EN EL SISTEMA - CON UN MINIMO POR LEY  #####

        public static int DiasUtilidades = 30;  //###  1.  DIAS A PAGAR POR UTILIDADES  ###
        public static int DiasBonoPerm = 0;     //###  2.  DIAS DE BONO DE PERMANENCIA  ###
        public static int DiasAporte = 15;      //###  3.  DIAS DE APORTE SE LE HACE AL EMPLEADO CADA (MesesAporte) MESES  ###
        public static int DiasAdicPrestSoc = 2; //###  4.  DIAS ADICIONALES DE PRESTACIONES SOCIALES DESPUES DEL SEGUNDO AÑO  ###
        public static int TopeDiasAdicPS = 30;  //###  5.  TOPE DE DIAS ADICIONALES DE PRESTACIONES SOCIALES  ###
        public static decimal Rec1erDesc = 1.0m;//###  6.  RECARGO DEL PRIMER DESCANSO LABORADO  ###    
        public static decimal Rec2doDesc = 1.5m;//###  7.  RECARGO DEL SEGUNDO DESCANSO LABORADO  ###
        public static decimal RecDomingo = 1.5m;//###  8.  RECARGO POR EL FERIADO LABORADO  ###
        public static decimal RecFeriado = 1.5m;//###  9.  RECARGO POR EL FERIADO LABORADO  ###
        public static decimal RecHorExt = 1.5m; //###  10. RECARGO POR HORAS EXTRAS TRABAJADAS  ###
        public static int VacAnuales = 15;      //###  11. VACACIONES MINIMAS ANUALES  ###
        public static int DiasAdicVac = 1;      //###  12. DIAS ADICIONALES DE VACACIONES ANUALES MINIMO DE EMPLEADO ###
        public static int TopeDiasAdicVac = 15; //###  13. TOPE DE DIAS ADICIONALES POR AÑO
        public static int DiasBonoVac = 15;     //###  14. DIAS DE BONO VACACIONAL POR AÑO MINIMO DE UN EMPLEADO  ###    
        public static int DiasAdicBonoVac = 1;  //###  15. DIAS ADICIONALES DE BONO VACACIONAL POR AÑO  ###
        public static int TopeBonoVac = 30;     //###  16. DIAS DE BONO VAVACIONAL MAXIMO DE UN EMPLEADO  ###
        public static int BonoAprendices = 15;  //###  17. BONO VACACIONAL ANUAL PARA APRENDICES INCE  ###
        public static int VacAprendices = 22;   //###  18. VACACIONES ANUALES PARA APRENDIS INCE  ###
        public static decimal SalMin = 0;       //###  24. SALARIO MINIMO VIGENTE
        public static decimal SalMinApre = 0;   //###  25. SALARIO MINIMO APREDIZ INCE VIGENTE    
        public static decimal TopeSSO = 1;      //###  26. TOPE DEL SEGURO SOCIAL EN SALARIOS MINIMO  ###
        public static decimal MontSSO = 0;      //###  27. MONTO DE RETENCION DEL SEGURO SOCIAL  ###
        public static decimal TopeRPPE = 1;     //###  28. TOPE DEL REGIMEN PRESTACIONAL DE EMPLEO EN SALARIOS MINIMO  ###
        public static decimal MontRPPE = 0;     //###  29. MONTO DE RETENCION DEL REGIMEN PRESTACIONAL DE EMPLEO  ###
        public static decimal MontRPVH = 0;     //###  30. MONTO DE RETENCION DE REG. PREST. DE VIVIENDA Y HABITAT  ###
        public static decimal TopeTickAlim = 3; //###  31. SALARIOS TOPE PARA EL TICKET DE ALIMENTACION  ###
        public static decimal TicketAli = 112.5m;//###  32. MONTO DEL TICKET DE ALIMENTACION  ###
        public static decimal TicketBas = 112.5m;//###  33. MONTO DEL TICKET BASE AMPLIA  ###
        public static decimal TicketAliApre = 63.5m;//###  34. MONTO DEL TICKET DE ALIMENTACION INCE  ###
        public static decimal MultInce = 0;      //###  35. IMPUESTO INCE


        //#####  CONSTANTES UTILIZADAS EN EL SISTEMA - NO MODIFICABLES POR LEY  #####

        public static int MPATSalMix = 6;       //###  MESES DE PROMEDIO PARA EL ABONO TRIMESTRAL DE SALARIO MIXTO  ###
        public static int MPVacac = 3;          //###  MESES DE PROMEDIO PARA EL CALCULO DE VACACIONES Y ALICUOTA DE BONO VACACIONAL  ##
        public static int MPAliUtil = 3;        //###  MESES DE PROMEDIO PARA EL CALCULO DE LA ALICUOTA DE UTILIDAD  ###
        public static int MPAliUtilDA = 6;      //###  MESES DE PROMEDIO PARA EL CALCULO DE LA ALICUOTA DE UTILIDAD DE DIAS ADICIONALES  ###
        public static int MesesAporte = 3;      //###  CADA CUANTOS MESES SE HACE UN APORTE A PRESTACIONES SOCIALES  ###


        //##### CONSTANTES PERSONLIZADAS POR LA EMPRESA

        public static decimal BonoAsisPerf = 0; //###  BONO DE ASISTENCIA PERFECTA OTORGADO POR LA EMPRESA  ###
        public static int TopePrimAnt = 0;      //###  TOPE DE LA PRIMA DE ANTIGUEDAD OTORGADO POR LA EMPRESA  ###
        public static int MesPagoUtil = 1;      //###  MES PARA EL INICIO DEL PAGO DE UTILIDADES DE LA EMPRESA  ### 
        public static int DiaPagQuin = 8;       //###  DIA MINIMO PARA COBRAR EL PRESTAMO DE LA PRIMERA QUINCENA  ###
        public static int DiaPagMen = 23;       //###  DIA MINIMO PARA COBRAR EL PRESTAMO DE LA SEGUNDA QUINCENA  ###


        //%%%%%  CONSTANTES MODIFICABLES EN BASE DE DATOS  %%%%%
    }
}
