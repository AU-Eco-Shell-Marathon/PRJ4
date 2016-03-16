/* ========================================
 *
 * Copyright YOUR COMPANY, THE YEAR
 * All Rights Reserved
 * UNPUBLISHED, LICENSED SOFTWARE.
 *
 * CONFIDENTIAL AND PROPRIETARY INFORMATION
 * WHICH IS THE PROPERTY OF your company.
 *
 * ========================================
*/
#include "Pedal.h"

uint16 set_ = 0;

const uint16 *Pedal_init()
{
    return &set_;
}

void Pedal_update()
{
    set_ = 15u * Status_Reg_1_Read()&0b1;
}

/* [] END OF FILE */
