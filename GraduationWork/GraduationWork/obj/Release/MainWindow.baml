   M S B A M L   `   `   `  ����   GraduationWork    GraduationWork.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$  GraduationWork��$	��450��$	��800�� � WindowState$ 	Maximized=�.��� $��2q�.+�]� $��24����.  $	��Top=�.+�� -    �Name$ MainMenu��$��24��$	��Top=�$	��787��.+��� -    ��Name$ btChangeBackColor��$��Цвет фона��$	��134��$��Bottom=�$
��Left=��� -   $ btChangeFont��$��
Шрифт��$	��134��$��Bottom=�$
��Left=��� -   $ btChangeFontColor��$��Цвет шрифта���� -    ��Name$ tcMain��$��0,24,0,0q� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� ��  �� AngleY$ 0.128Q��� T�  T� Y$ 0.498Q�.@��� -    ��Name$ tabNewOrder��$��Новый заказ��.��� -   $ GridNewOrder�����	#FFE5E5E5.+�&   System.Windows.Controls.DataGrid  -	   	  Name$	 gridNewOrder��
   AutoGenerateColumns
 .     
IsReadOnly . $��0,0,0,25q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   MinWidth$	 100Q�-
   fieldNewOrderProductName��   Header$ Наименование��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Product.Name+  $	 100Q�-    fieldNewOrderProductQuantity��$ Количество�� �� *
Quantity+  $	 100Q�-   fieldProductTotalPrice��$ 
Сумма�� �� *ProductTotalPrice+�� -   $ btAddNewOrder��$%��Добавить позицию��$	��134��$��Bottom=�$
��Left=�$��25���� -   $ btEditNewOrder��$/��)Редактировать позицию��$	��164��$��Bottom=�$
��Left=�$��25��$��	134,0,0,0q��� -   $ btDeleteNewOrder��$#��Удалить позицию��$	��127��$��Bottom=�$
��Left=�$��25��$��	298,0,0,0q��� -   $ btClearNewOrder��$��Очистить��$��85��$��Bottom=�$
��Left=�$��25��$��	425,0,0,0q��� -   $ btMakeNewOrder��$!��Оформить заказ��$��Bottom=�$��25��$��	631,0,0,0q�$��Right=����	#FFF7F7FA$
��Bold"��� -   $ 	tabOrders��$#��История заказов��.��� ���	#FFE5E5E5.+�  -   $	 
gridOrders��
 .   .    �� -   $ tabProducts��$��Продукты��.��� ���	#FFE5E5E5.+�  -   $	 gridProducts��
 .     $	 100Q�-   fieldProductName��$ Наименование�� �� *Name+  $	 100Q�-   fieldProductDescription��$ Описание�� �� *Description+  $	 100Q�-   fieldProductPrice��$ Цена�� �� *Price+�� -   $ tabCustomers��$��Покупатели��.��� -   $ GridCustomers�����	#FFE5E5E5.+�  -   $	 gridCustomers��
 .   . $��0,0,0,25q�   $	 100Q�-   fieldCustomerUserName��$ Пользователь�� �� *	User.Name+  $	 100Q�-   fieldCustomerFIO��$ ФИО�� �� *FIO+  $	 100Q�-   fieldCustomerBirthday��$ Дата рождения�� �� *
Birthday+�� -   $ btAddCustomer��$��Добавить��$��80��$��Bottom=�$
��Left=�$��25���� -    $ btEditCustomer��$ ��Редактировать��$	��110��$��Bottom=�$
��Left=�$��25��$��80,0,0,0q��� -!   $ btDeleteCustomer��$��Удалить��$��80��$��Bottom=�$
��Left=�$��25��$��	190,0,0,0q��� -"   $ tabManagers��$��Менеджеры��.��� -#   $ GridManagers�����	#FFE5E5E5.+�  -$   $	 gridManagers��
 .   . $��0,0,0,25q�   $	 100Q�-%   fieldManagerUserId��$ Пользователь�� �� *	User.Name+  $	 100Q�-&   fieldManagerFIO��$ ФИО�� �� *FIO+�� -'   $ btAddManager��$��Добавить��$��80��$��Bottom=�$
��Left=�$��25���� -(   $ btEditManager��$ ��Редактировать��$	��110��$��Bottom=�$
��Left=�$��25��$��80,0,0,0q��� -)   $ btDeleteManager��$��Удалить��$��80��$��Bottom=�$
��Left=�$��25��$��	190,0,0,0q��� -*   $ tabUsers��$��Пользователи��.��� ���	#FFE5E5E5.+�  -+   $	 	gridUsers��
 .     $	 100Q�-,   fieldUserName��$ 
Логин�� �� *Name+  $	 100Q�--   fieldUserPassword��$ Пароль�� �� *
Password+