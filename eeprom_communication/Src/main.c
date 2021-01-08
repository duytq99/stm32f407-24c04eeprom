
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
  ******************************************************************************
  ** This notice applies to any and all portions of this file
  * that are not between comment pairs USER CODE BEGIN and
  * USER CODE END. Other portions of this file, whether 
  * inserted by the user or by software development tools
  * are owned by their respective copyright owners.
  *
  * COPYRIGHT(c) 2021 STMicroelectronics
  *
  * Redistribution and use in source and binary forms, with or without modification,
  * are permitted provided that the following conditions are met:
  *   1. Redistributions of source code must retain the above copyright notice,
  *      this list of conditions and the following disclaimer.
  *   2. Redistributions in binary form must reproduce the above copyright notice,
  *      this list of conditions and the following disclaimer in the documentation
  *      and/or other materials provided with the distribution.
  *   3. Neither the name of STMicroelectronics nor the names of its contributors
  *      may be used to endorse or promote products derived from this software
  *      without specific prior written permission.
  *
  * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
  * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
  * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
  * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
  * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
  * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
  * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
  * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
  * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
  * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
  *
  ******************************************************************************
  */
/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "stm32f4xx_hal.h"

/* USER CODE BEGIN Includes */
#include <stdlib.h>
#include <string.h>
/* USER CODE END Includes */

/* Private variables ---------------------------------------------------------*/
I2C_HandleTypeDef hi2c1;
I2C_HandleTypeDef hi2c2;
DMA_HandleTypeDef hdma_i2c1_rx;
DMA_HandleTypeDef hdma_i2c1_tx;

UART_HandleTypeDef huart4;
DMA_HandleTypeDef hdma_uart4_tx;

/* USER CODE BEGIN PV */
/* Private variables ---------------------------------------------------------*/

/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
static void MX_GPIO_Init(void);
static void MX_DMA_Init(void);
static void MX_I2C1_Init(void);
static void MX_I2C2_Init(void);
static void MX_UART4_Init(void);

/* USER CODE BEGIN PFP */
/* Private function prototypes -----------------------------------------------*/
uint16_t string_to_number(uint8_t address[])
{
	volatile uint16_t result=0;
	volatile uint8_t a,b,c=0;
	
	if ((address[0]<= 57)&(address[0]>=48))
			a = address[0] - 48;
		else if ((address[0]>=65)&(address[0]<=70))
			a = address[0] - 55;
		else if ((address[0]>=97)&(address[0]<=102))
			a = address[0] - 87;
		
		if ((address[1]<= 57)&(address[1]>=48))
			b = address[1] - 48;
		else if ((address[1]>=65)&(address[1]<=70))
			b = address[1] - 55;
		else if ((address[1]>=97)&(address[1]<=102))
			b = address[1] - 87;
		
		if ((address[2]<= 57)&(address[2]>=48))
			c = address[2] - 48;
		else if ((address[2]>=65)&(address[2]<=70))
			c = address[2] - 55;
		else if ((address[2]>=97)&(address[2]<=102))
			c = address[2] - 87;
		
		result = a*16*16 + b*16 + c;
	
	return result;
	}


	
void Write_Mem(uint16_t address_from, uint16_t address_to, uint8_t content[])	;
	/* USER CODE END PFP */

/* USER CODE BEGIN 0 */

typedef unsigned char Byte; 

uint8_t received_char;
uint8_t i, splitter_counter=1, str_index = 0, add1_index=0, add2_index=0, data_index=0 ;

uint8_t received_data[530];
uint8_t check1[2] = ".\n"; //debug
uint8_t check2[6] = "CHECK\n";
// unsigned char EOL_char = '_'; //debug hercules
uint8_t EOL_char = '\n';

uint8_t address1[3], address2[3];
uint16_t address1_num, address2_num;
uint8_t write_content[512];

uint8_t memory_data[512] = {0};
uint8_t xoa[16] = {0};
uint8_t xoa_n[512] = {0};

#define EEPROMM_ADDRESS  0xA0
/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  *
  * @retval None
  */
int main(void)
{
  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration----------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_DMA_Init();
  MX_I2C1_Init();
  MX_I2C2_Init();
  MX_UART4_Init();
  /* USER CODE BEGIN 2 */
	
	
	__HAL_UART_FLUSH_DRREGISTER(&huart4);
	HAL_UART_Receive_IT(&huart4, &received_char, 1);
	
	// quet toan bo eeprom, luu vao mang memory_data
	if (HAL_I2C_Mem_Read_DMA(&hi2c1, (uint16_t)EEPROMM_ADDRESS, 0, I2C_MEMADD_SIZE_8BIT, (uint8_t *)memory_data, 512) != HAL_OK)
  {
    /* Reading process Error */
    Error_Handler();
  }

  /* Wait for the end of the transfer */
  while (HAL_I2C_GetState(&hi2c1) != HAL_I2C_STATE_READY)
  {
  }
	
  /* USER CODE END 2 */

  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
  while (1)
  {

  /* USER CODE END WHILE */

  /* USER CODE BEGIN 3 */

	HAL_GPIO_TogglePin(GPIOD, GPIO_PIN_12|GPIO_PIN_15);
	HAL_Delay(100);
	while (HAL_I2C_Mem_Read_DMA(&hi2c1, (uint16_t)EEPROMM_ADDRESS, 0, I2C_MEMADD_SIZE_8BIT, (uint8_t *)memory_data, 512) != HAL_OK);
//  {
//    /* Reading process Error */
//    Error_Handler();
//  }
	// HAL_UART_Transmit(&huart4, check2, sizeof(check2));
  
  }
  /* USER CODE END 3 */

}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{

  RCC_OscInitTypeDef RCC_OscInitStruct;
  RCC_ClkInitTypeDef RCC_ClkInitStruct;

    /**Configure the main internal regulator output voltage 
    */
  __HAL_RCC_PWR_CLK_ENABLE();

  __HAL_PWR_VOLTAGESCALING_CONFIG(PWR_REGULATOR_VOLTAGE_SCALE1);

    /**Initializes the CPU, AHB and APB busses clocks 
    */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSI;
  RCC_OscInitStruct.HSIState = RCC_HSI_ON;
  RCC_OscInitStruct.HSICalibrationValue = 16;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSI;
  RCC_OscInitStruct.PLL.PLLM = 8;
  RCC_OscInitStruct.PLL.PLLN = 168;
  RCC_OscInitStruct.PLL.PLLP = RCC_PLLP_DIV2;
  RCC_OscInitStruct.PLL.PLLQ = 7;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    _Error_Handler(__FILE__, __LINE__);
  }

    /**Initializes the CPU, AHB and APB busses clocks 
    */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV4;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV2;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_5) != HAL_OK)
  {
    _Error_Handler(__FILE__, __LINE__);
  }

    /**Configure the Systick interrupt time 
    */
  HAL_SYSTICK_Config(HAL_RCC_GetHCLKFreq()/1000);

    /**Configure the Systick 
    */
  HAL_SYSTICK_CLKSourceConfig(SYSTICK_CLKSOURCE_HCLK);

  /* SysTick_IRQn interrupt configuration */
  HAL_NVIC_SetPriority(SysTick_IRQn, 0, 0);
}

/* I2C1 init function */
static void MX_I2C1_Init(void)
{

  hi2c1.Instance = I2C1;
  hi2c1.Init.ClockSpeed = 100000;
  hi2c1.Init.DutyCycle = I2C_DUTYCYCLE_2;
  hi2c1.Init.OwnAddress1 = 0;
  hi2c1.Init.AddressingMode = I2C_ADDRESSINGMODE_7BIT;
  hi2c1.Init.DualAddressMode = I2C_DUALADDRESS_DISABLE;
  hi2c1.Init.OwnAddress2 = 0;
  hi2c1.Init.GeneralCallMode = I2C_GENERALCALL_DISABLE;
  hi2c1.Init.NoStretchMode = I2C_NOSTRETCH_DISABLE;
  if (HAL_I2C_Init(&hi2c1) != HAL_OK)
  {
    _Error_Handler(__FILE__, __LINE__);
  }

}

/* I2C2 init function */
static void MX_I2C2_Init(void)
{

  hi2c2.Instance = I2C2;
  hi2c2.Init.ClockSpeed = 100000;
  hi2c2.Init.DutyCycle = I2C_DUTYCYCLE_2;
  hi2c2.Init.OwnAddress1 = 0;
  hi2c2.Init.AddressingMode = I2C_ADDRESSINGMODE_7BIT;
  hi2c2.Init.DualAddressMode = I2C_DUALADDRESS_DISABLE;
  hi2c2.Init.OwnAddress2 = 0;
  hi2c2.Init.GeneralCallMode = I2C_GENERALCALL_DISABLE;
  hi2c2.Init.NoStretchMode = I2C_NOSTRETCH_DISABLE;
  if (HAL_I2C_Init(&hi2c2) != HAL_OK)
  {
    _Error_Handler(__FILE__, __LINE__);
  }

}

/* UART4 init function */
static void MX_UART4_Init(void)
{

  huart4.Instance = UART4;
  huart4.Init.BaudRate = 115200;
  huart4.Init.WordLength = UART_WORDLENGTH_8B;
  huart4.Init.StopBits = UART_STOPBITS_1;
  huart4.Init.Parity = UART_PARITY_NONE;
  huart4.Init.Mode = UART_MODE_TX_RX;
  huart4.Init.HwFlowCtl = UART_HWCONTROL_NONE;
  huart4.Init.OverSampling = UART_OVERSAMPLING_16;
  if (HAL_UART_Init(&huart4) != HAL_OK)
  {
    _Error_Handler(__FILE__, __LINE__);
  }

}

/** 
  * Enable DMA controller clock
  */
static void MX_DMA_Init(void) 
{
  /* DMA controller clock enable */
  __HAL_RCC_DMA1_CLK_ENABLE();

  /* DMA interrupt init */
  /* DMA1_Stream0_IRQn interrupt configuration */
  HAL_NVIC_SetPriority(DMA1_Stream0_IRQn, 0, 0);
  HAL_NVIC_EnableIRQ(DMA1_Stream0_IRQn);
  /* DMA1_Stream4_IRQn interrupt configuration */
  HAL_NVIC_SetPriority(DMA1_Stream4_IRQn, 0, 0);
  HAL_NVIC_EnableIRQ(DMA1_Stream4_IRQn);
  /* DMA1_Stream6_IRQn interrupt configuration */
  HAL_NVIC_SetPriority(DMA1_Stream6_IRQn, 0, 0);
  HAL_NVIC_EnableIRQ(DMA1_Stream6_IRQn);

}

/** Configure pins as 
        * Analog 
        * Input 
        * Output
        * EVENT_OUT
        * EXTI
*/
static void MX_GPIO_Init(void)
{

  GPIO_InitTypeDef GPIO_InitStruct;

  /* GPIO Ports Clock Enable */
  __HAL_RCC_GPIOH_CLK_ENABLE();
  __HAL_RCC_GPIOA_CLK_ENABLE();
  __HAL_RCC_GPIOB_CLK_ENABLE();
  __HAL_RCC_GPIOD_CLK_ENABLE();

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOD, GPIO_PIN_12|GPIO_PIN_13|GPIO_PIN_14|GPIO_PIN_15, GPIO_PIN_RESET);

  /*Configure GPIO pins : PD12 PD13 PD14 PD15 */
  GPIO_InitStruct.Pin = GPIO_PIN_12|GPIO_PIN_13|GPIO_PIN_14|GPIO_PIN_15;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
  HAL_GPIO_Init(GPIOD, &GPIO_InitStruct);

}

/* USER CODE BEGIN 4 */
void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart) // chuong trinh ngat rx uart
	/* Rx callback for uart interrupt */
	{
		__HAL_UART_FLUSH_DRREGISTER(&huart4); // Clear the buffer to prevent overrun
		if (received_char == EOL_char) // ket thuc nhan vao 1 lenh
			{
				received_data[str_index] = received_char;
				str_index++;
				
				// HAL_UART_Transmit(&huart4, received_data, str_index);
				
				if (received_data[0]=='w')
				{
					/* command splitter for write command */
					for (i=2; i<str_index; i++)
					{
						if (received_data[i]=='-')
						{
							splitter_counter++;
						}
						if (splitter_counter==2)
						{
							if (received_data[i+1]==EOL_char)
								break;
							write_content[data_index] = received_data[i+1];
							data_index++;
						}
						else
						{
							address1[add1_index] = received_data[i];
							add1_index++;
						}
					}		
					
					address1_num = string_to_number(address1);
					address2_num = address1_num + data_index;
					
					Write_Mem(address1_num, address2_num, write_content);
 					
					// done
					/* write memory */
					
					/* command splitter for write command */
				}
				else if (received_data[0]=='r')
				{
					/* command splitter for read command */
					if (received_data[2] == '1')
					{
						for (i=4; i<str_index-1; i++)
						{
							address1[add1_index] = received_data[i];
							add1_index++;
						}
						address1_num = string_to_number(address1);
						// su dung mang da doc tu DMA circular
						HAL_UART_Transmit(&huart4, (uint8_t*)(&memory_data[address1_num]), 1, 100);
						// done
						// read 1 
					}
					else if (received_data[2] == 'n')
					{
						for (i=4; i<str_index-1; i++)
						{
							if (received_data[i] == '-')
							{
								splitter_counter++;
							}
							else if (splitter_counter==2)
							{
								address2[add2_index] = received_data[i];
								add2_index++;
							}
							else
							{
								address1[add1_index] = received_data[i];
								add1_index++;
							}
						}
						address1_num = string_to_number(address1);
						address2_num = string_to_number(address2);
						
						// su dung mang da doc tu DMA circular
						if (HAL_UART_Transmit(&huart4, (uint8_t*)&(memory_data[address1_num]), address2_num - address1_num + 1, 100) != HAL_OK)
						{
							Error_Handler();
						}

						// done
						// read n
					}
					// read memory from address: address1
					// to address: address2
					/* command splitter for read command */
				}
				else if (received_data[0]=='d')
				{
					/* command splitter for delete command */
					if (received_data[2] == '1')
					{
						for (i=4; i<str_index-1; i++)
						{
							address1[add1_index] = received_data[i];
							add1_index++;
						}
						address1_num = string_to_number(address1);
						uint8_t xoa1 = 0;
						if (address1_num<256)
							{
							while (HAL_I2C_Mem_Write(&hi2c1, EEPROMM_ADDRESS, address1_num, I2C_MEMADD_SIZE_8BIT, &xoa1, 1, 100) != HAL_OK);
							HAL_Delay(10);
							}
						else
							{
							while (HAL_I2C_Mem_Write(&hi2c1, EEPROMM_ADDRESS+2, address1_num, I2C_MEMADD_SIZE_8BIT, &xoa1, 1, 100) != HAL_OK);
							HAL_Delay(10);
							}
							// done
						//delete at address1
					}
					else if (received_data[2] == 'n')
					{
						for (i=4; i<str_index-1; i++)
						{
							if (received_data[i] == '-')
							{
								splitter_counter++;
							}
							else if (splitter_counter==2)
							{
								address2[add2_index] = received_data[i];
								add2_index++;
							}
							else
							{
								address1[add1_index] = received_data[i];
								add1_index++;
							}
						}
						address1_num = string_to_number(address1);
						address2_num = string_to_number(address2);
						
						Write_Mem(address1_num, address2_num, xoa_n);
						// done
						//delete from address1 to address2
					}
					else if (received_data[2] == 'a') //xoa het
					{
						for (int j=0; j<16; j++)
							{
								while (HAL_I2C_Mem_Write(&hi2c1, EEPROMM_ADDRESS, j*16, I2C_MEMADD_SIZE_8BIT, xoa, 16, 100)!= HAL_OK);
								HAL_Delay(10);
							}
						for (int j=0; j<16; j++)
							{
								while (HAL_I2C_Mem_Write(&hi2c1, EEPROMM_ADDRESS + 2, j*16, I2C_MEMADD_SIZE_8BIT, xoa, 16, 100)!= HAL_OK);
								HAL_Delay(10);
							}
						// done
						// delete all
					}
					/* command splitter for delete command */
				}
				else if (received_data[0]=='s')
				{
					/* command splitter for scan command */
					while (HAL_UART_Transmit(&huart4, (uint8_t*)memory_data, 512, 100) != HAL_OK);
					HAL_Delay(10);
					/* command splitter for scan command */
				}
				str_index = 0;
				splitter_counter = 1;
				data_index = 0;
				add1_index = 0;
				add2_index = 0;
			}
		else
			{
				received_data[str_index] = received_char;
				str_index++;
			}
		HAL_UART_Receive_IT(&huart4, &received_char, 1); 
	}
	
void Write_Mem(uint16_t address_from, uint16_t address_to, uint8_t content[])
{
	uint16_t number_of_bytes = address_to - address_from;
	uint16_t remaining_bytes = number_of_bytes;
	if (address_to <= 255)
	{
		while (remaining_bytes > 0)
		{
			while (HAL_I2C_Mem_Write(&hi2c1 , 0xA0, address_from, I2C_MEMADD_SIZE_8BIT, (uint8_t*)&(content[number_of_bytes - remaining_bytes]), 1, 10)!= HAL_OK)
			{
				/* Writing process Error */
				// Error_Handler();
			}
			remaining_bytes -= 1;
			address_from += 1;
		}
	}
	else if (address_from > 255)
	{
		while (remaining_bytes > 0)
		{
			while (HAL_I2C_Mem_Write(&hi2c1 , 0xA2, address_from - 256, I2C_MEMADD_SIZE_8BIT, (uint8_t*)&(content[number_of_bytes - remaining_bytes]), 1, 10)!= HAL_OK)
			{
				/* Writing process Error */
				// Error_Handler();
			}
			remaining_bytes -= 1;
			address_from += 1;
			}
		}
	else
	{
		uint8_t page_address;
		while (remaining_bytes > 0)
		{	
			if (address_from >= 256)
			{
				page_address = 0xA2;
				// address_from -= 256; 
			}
			else
				page_address = 0xA0;
			while (HAL_I2C_Mem_Write(&hi2c1 , page_address, address_from, I2C_MEMADD_SIZE_8BIT, (uint8_t*)&(content[number_of_bytes - remaining_bytes]), 1, 10)!= HAL_OK)
			{
				/* Writing process Error */
				// Error_Handler();
			}
			remaining_bytes -= 1;
			address_from += 1;
		}
	}
}
	
/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @param  file: The file name as string.
  * @param  line: The line in file as a number.
  * @retval None
  */
void _Error_Handler(char *file, int line)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */
  while(1)
  {
		HAL_GPIO_TogglePin(GPIOD, GPIO_PIN_13);
		HAL_Delay(200);
	}
  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t* file, uint32_t line)
{ 
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     tex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */

/**
  * @}
  */

/**
  * @}
  */

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/
