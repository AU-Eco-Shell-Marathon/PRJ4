/*******************************************************************************
* File Name: V_motor.h  
* Version 2.10
*
* Description:
*  This file containts Control Register function prototypes and register defines
*
* Note:
*
********************************************************************************
* Copyright 2008-2014, Cypress Semiconductor Corporation.  All rights reserved.
* You may use this file only in accordance with the license, terms, conditions, 
* disclaimers, and limitations in the end user license agreement accompanying 
* the software package with which this file was provided.
*******************************************************************************/

#if !defined(CY_PINS_V_motor_H) /* Pins V_motor_H */
#define CY_PINS_V_motor_H

#include "cytypes.h"
#include "cyfitter.h"
#include "cypins.h"
#include "V_motor_aliases.h"

/* Check to see if required defines such as CY_PSOC5A are available */
/* They are defined starting with cy_boot v3.0 */
#if !defined (CY_PSOC5A)
    #error Component cy_pins_v2_10 requires cy_boot v3.0 or later
#endif /* (CY_PSOC5A) */

/* APIs are not generated for P15[7:6] */
#if !(CY_PSOC5A &&\
	 V_motor__PORT == 15 && ((V_motor__MASK & 0xC0) != 0))


/***************************************
*        Function Prototypes             
***************************************/    

void    V_motor_Write(uint8 value) ;
void    V_motor_SetDriveMode(uint8 mode) ;
uint8   V_motor_ReadDataReg(void) ;
uint8   V_motor_Read(void) ;
uint8   V_motor_ClearInterrupt(void) ;


/***************************************
*           API Constants        
***************************************/

/* Drive Modes */
#define V_motor_DM_ALG_HIZ         PIN_DM_ALG_HIZ
#define V_motor_DM_DIG_HIZ         PIN_DM_DIG_HIZ
#define V_motor_DM_RES_UP          PIN_DM_RES_UP
#define V_motor_DM_RES_DWN         PIN_DM_RES_DWN
#define V_motor_DM_OD_LO           PIN_DM_OD_LO
#define V_motor_DM_OD_HI           PIN_DM_OD_HI
#define V_motor_DM_STRONG          PIN_DM_STRONG
#define V_motor_DM_RES_UPDWN       PIN_DM_RES_UPDWN

/* Digital Port Constants */
#define V_motor_MASK               V_motor__MASK
#define V_motor_SHIFT              V_motor__SHIFT
#define V_motor_WIDTH              1u


/***************************************
*             Registers        
***************************************/

/* Main Port Registers */
/* Pin State */
#define V_motor_PS                     (* (reg8 *) V_motor__PS)
/* Data Register */
#define V_motor_DR                     (* (reg8 *) V_motor__DR)
/* Port Number */
#define V_motor_PRT_NUM                (* (reg8 *) V_motor__PRT) 
/* Connect to Analog Globals */                                                  
#define V_motor_AG                     (* (reg8 *) V_motor__AG)                       
/* Analog MUX bux enable */
#define V_motor_AMUX                   (* (reg8 *) V_motor__AMUX) 
/* Bidirectional Enable */                                                        
#define V_motor_BIE                    (* (reg8 *) V_motor__BIE)
/* Bit-mask for Aliased Register Access */
#define V_motor_BIT_MASK               (* (reg8 *) V_motor__BIT_MASK)
/* Bypass Enable */
#define V_motor_BYP                    (* (reg8 *) V_motor__BYP)
/* Port wide control signals */                                                   
#define V_motor_CTL                    (* (reg8 *) V_motor__CTL)
/* Drive Modes */
#define V_motor_DM0                    (* (reg8 *) V_motor__DM0) 
#define V_motor_DM1                    (* (reg8 *) V_motor__DM1)
#define V_motor_DM2                    (* (reg8 *) V_motor__DM2) 
/* Input Buffer Disable Override */
#define V_motor_INP_DIS                (* (reg8 *) V_motor__INP_DIS)
/* LCD Common or Segment Drive */
#define V_motor_LCD_COM_SEG            (* (reg8 *) V_motor__LCD_COM_SEG)
/* Enable Segment LCD */
#define V_motor_LCD_EN                 (* (reg8 *) V_motor__LCD_EN)
/* Slew Rate Control */
#define V_motor_SLW                    (* (reg8 *) V_motor__SLW)

/* DSI Port Registers */
/* Global DSI Select Register */
#define V_motor_PRTDSI__CAPS_SEL       (* (reg8 *) V_motor__PRTDSI__CAPS_SEL) 
/* Double Sync Enable */
#define V_motor_PRTDSI__DBL_SYNC_IN    (* (reg8 *) V_motor__PRTDSI__DBL_SYNC_IN) 
/* Output Enable Select Drive Strength */
#define V_motor_PRTDSI__OE_SEL0        (* (reg8 *) V_motor__PRTDSI__OE_SEL0) 
#define V_motor_PRTDSI__OE_SEL1        (* (reg8 *) V_motor__PRTDSI__OE_SEL1) 
/* Port Pin Output Select Registers */
#define V_motor_PRTDSI__OUT_SEL0       (* (reg8 *) V_motor__PRTDSI__OUT_SEL0) 
#define V_motor_PRTDSI__OUT_SEL1       (* (reg8 *) V_motor__PRTDSI__OUT_SEL1) 
/* Sync Output Enable Registers */
#define V_motor_PRTDSI__SYNC_OUT       (* (reg8 *) V_motor__PRTDSI__SYNC_OUT) 


#if defined(V_motor__INTSTAT)  /* Interrupt Registers */

    #define V_motor_INTSTAT                (* (reg8 *) V_motor__INTSTAT)
    #define V_motor_SNAP                   (* (reg8 *) V_motor__SNAP)

#endif /* Interrupt Registers */

#endif /* CY_PSOC5A... */

#endif /*  CY_PINS_V_motor_H */


/* [] END OF FILE */
