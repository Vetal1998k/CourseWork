   M S B A M L   `   `   `  ����A  =Course, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CourseCourse  5   	       Course.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Course     5   	   -   5          � Title$  Регистрация��5   	   $��Arial)�5	   	   $��14(�5
   	   ���	#FFACC864���	#FFACC864 � WindowStartupLocation$ CenterScreen=�5   	    � Icon$0 *E:\Education\Course\Course\images\bank.ico��5   	   $��510.666��6;   $��426.666��6K    � 
ResizeMode$ NoResize=�6\   .��5      � ���	#FFFFFFDE$
��Left=�5   	   $	��511��5   	   $��0,0,-6,0q�5   	   .+�5   
   �� -   5         ��Name$ lb_name��5      $��Имя��5      $
��Left=�5      $��	10,50,0,0q�5      $	��Top=�5      ���	#FF0C1E0C5      �� 5   
   -   5        $ lb_sname��5      $��Фамилия��5      $
��Left=�5      $��10,3,0,0q�5      $	��Top=�5      ���	#FF0C1E0C5      �� 5    
   -   5         ��Name$ 	fist_name��5       $
��Left=�5!      $��24��5"      $��	10,76,0,0q�5#       �� TextWrapping$
 Wrap=�5$      $	��Top=�5%      $	��228��5&      
����������	#FF5884034  .System.Windows.Automation.AutomationProperties   HelpText$ Введите имя��5)      $��18(�6>   �� 5*   
   -   5        $ lb_position��5*      $��Должность��5+      $
��Left=�5,      $��258,100,0,0q�5-      $	��Top=�5.      ���	#FF0C1E0C5/      �� 50   
   -   5         ��Name$ position��50      $
��Left=�51      $��258,126,0,0q�52      $	��Top=�53      $	��228��54      ���	#FF588403���	#FF0C1E0C$��24��57      $) #Выберите должность��58      	 �� IsDropDownOpen	 .  ��5:      �� 5;      
 �� EndPoint$	
 0,1&�6&    �� 
StartPoint$	 0,0&�65   .��5<      �  � Color$ 	#FFF0F0F0��6#    � Offset$ 0Q�65   � 5=      $ 	#FF588403��6#   $ 1Q�65   5>      .@�5@      ��  �� Orientation$ 
Horizontal=�6   .+�5A      �� $0��*E:\Education\Course\Course\images\boss.png��6   $��16��6L   $��16��6W   $��
0, 0, 5, 0q�6c   6y   �� 5B      '%Руководитель отдела61   5C      �� 5D      $ 
Horizontal=�6   .+�5E      �� $8��2E:\Education\Course\Course\images\headofSector.png��6   $��16��6T   $��16��6_   $��
0, 0, 5, 0q�6k   6�   �� 5F      )'Руководитель сектора62   5G      �� 5H      $ 
Horizontal=�6   .+�5I      �� $6��0E:\Education\Course\Course\images\specialist.png��6   $��16��6R   $��16��6]   $��
0, 0, 5, 0q�6i   6   �� 5J      Специалист6(   5K      5L      �� 5M   
   -   5         ��Name$ btn_reg��5M      $��Регистрация��5N      $
��Left=�5O      $��142,354,0,0q�5P      $	��Top=�5Q      $��96��5R      $��28��6   ���	#FFB7CB4F���	#FF588403���	#FF0C1E0C$��1,1,1,1q�5W      �� 5X   
   -   5        $ second_name��5X      $
��Left=�5Y      $��24��5Z      $��	10,26,0,0q�6   $
 Wrap=�5[      $	��Top=�5\      $	��228��5]      
����������	#FF588403$# Введите Фамилию��5`      $��18(�6A   �� 5a   
   -	   5        $ lb_third��5a      $��Отчество��5b      $
��Left=�5c      $��
10,100,0,0q�5d      $	��Top=�5e      ���	#FF0C1E0C J� RenderTransformOrigin$ 0.31,-0.603&�5g      �� 5h   
   -
   5        $ 
third_name��5h      $
��Left=�5i      $��24��5j      $��
10,126,0,0q�5k      $
 Wrap=�5l      $	��Top=�5m      $	��228��5n      
����������	#FF588403$% введите отчество��5q      $��18(�6C   (  "System.Windows.Controls.DatePicker  5r   
   -   5          Name$
 date��5r      $
��Left=�5s      $��
258,26,0,0q�5t      $	��Top=�5u      $	��228��5v         FirstDayOfWeek$ Monday=�5w         DisplayDateEnd$ 
1998-12-31X�5x         DisplayDateStart$ 
1947-12-31X�5y      $. (Введите дату рождения��5z         Text$ Дата Рождения��6K   �� 5{   
   -   5        $ btn_employee��5{      $��Сотрудники��5|      $
��Left=�5}      $��
10,354,0,0q�5~      $	��Top=�5      $��96��5�      $��28��6   ���	#FF588403���	#FF0C1E0C���	#FFB7CB4F5�   ,   �� 5�   
   -   5        $ btn_exit��5�      $��
Выход��5�      $
��Left=�5�      $��	438,3,0,0q�5�      $	��Top=�5�      $��48��5�      ���	#FF22E00F��5�      Z� ��5�      Z� 5�      �� 5�   
   $��Начальник��6   $
��Left=�6$   $��
10,155,0,0q�6?   $	��Top=�6S   ���	#FFB7CB4F$��16(�6�   �� 5�   
   -   5        $ adress��5�      $
��Left=�5�      $��24��5�      $��
258,76,0,0q�6   $
 Wrap=�5�      $	��Top=�5�      $	��228��5�      
����������	#FF588403$ Введите имя��5�      $��18(�69   �� 5�   
   -   5        $ 	lb_adress��5�      $��Адресс��5�      $
��Left=�5�      $��
258,50,0,0q�5�      $	��Top=�5�      ���	#FF0C1E0C5�      �� 5�   
   -   5        $ lb_date��5�      $��Дата��5�      $
��Left=�5�      $��	258,0,0,0q�5�      $	��Top=�5�      ���	#FF0C1E0C5�      �� 5�   
   $	��148��6   $��258,188,25,0q�6   $5��/E:\Education\Course\Course\images\employees.png��63   $	��Top=�6l   �� 5�   
   -   5         ��Name$ lst_of_chiefs��5�      $
��Left=�6)   $	��148��6D   $��
10,188,0,0q�6Q   $	��Top=�6e   $	��228��6}   $��10(�6�   {�.  6�   5�      5�      