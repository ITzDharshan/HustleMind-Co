   M S B A M L   `   `   `  ���� U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf   HustleMind Co.(   "HustleMind_Co_.Pages.DashboardPage   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf       N� Title$  DashboardPage��.���  � ColumnDefinitions �� $	��200 ��� $��* �.+��� $��0������  �� 
StartPoint$ 0.5,0&� �� EndPoint$ 0.5,1&�.���  � Color$ 	#FF7226FF�� � Offset$ 0Q�� $ 	#FF160078��$
 0.65Q�� $ 	#FF010030��$ 1Q�.+��� $	��120��$	��120��$��/Assets/jet.png��$��	0,20,0,10q�$��Center=��� 
������ $��0q�$��0,30,0,0q�$��Stretch=�$	��Top=�
�������$��16(�$��Poppins)� �� SelectionMode$ Single=� �� SelectedItem �� *SelectedMenuItem+.@��� -   $��15q� � Cursor$
 Hand��.���� 	 �� Orientation$	 
Horizontal=�$��Center=�.+��� $��Segoe MDL2 Assets)�$	����$��0,0,15,0q�$��20(��� $��	Dashboard��$��Center=�$��SemiBold"��� -   $��15q�$
 Hand��.���� $	 
Horizontal=�$��Center=�.+��� $��Segoe MDL2 Assets)�$	����$��0,0,15,0q�$��20(��� $��	Customers��$��Center=�$��SemiBold"��� -   $��15q�$
 Hand��.���� $	 
Horizontal=�$��Center=�.+��� $��Segoe MDL2 Assets)�$	����$��0,0,15,0q�$��20(��� $��Projects��$��Center=�$��SemiBold"��� -   $��15q�$
 Hand��.���� $	 
Horizontal=�$��Center=�.+��� $��Segoe MDL2 Assets)�$	����$��0,0,15,0q�$��20(��� $��Payments��$��Center=�$��SemiBold"��� -   $��15q�$
 Hand��.���� $	 
Horizontal=�$��Center=�.+��� $��Segoe MDL2 Assets)�$	����$��0,0,15,0q�$��20(��� $��Reviews��$��Center=�$��SemiBold"��� $	��120��
������ �� -   $��15q�$
 Hand��.���� $	 
Horizontal=�$��Center=�$��21��.+��� $��Segoe MDL2 Assets)�$	����$��0,0,15,0q�$��20(�� $��1��
�������.+�� $��20q� �� $��2* ��� $��1* �.+��� $��0��.+��� -   
 ��Name$
 GreetingText��$��26(�$
��Bold"�$��0,0,0,20q�$��Poppins)�� $��0,0,0,20q� �� $	��69* ��� $	��59* ��� $
��128* ��� $	��64* �.+��� $��0�����#FFF8E1 �� CornerRadius$ 15��$��10,10,112,10q� �� Padding$ 20q����#F9D342$��1q�$��2��._��� .+��� $��/Assets/team.png��$��50��$��50��$��Center=��� $��Poppins)�$��Total Customers��$��SemiBold"�$��12(�$��0,10,0,5q�$��Center=��� -   $
 txtTotalCustomers��$��Poppins)�$
��Bold"�$��20(����#333$��Center=��� $��1�����#FFEBE6$ 15��$��20,10,236,10q�$ 20q����#FF9B85$��1q�$��2��._��� .+��� $��/Assets/project.png��$��50��$��50��$��Center=��� $��Poppins)�$��Total Projects��$��SemiBold"�$��12(�$��0,10,0,5q�$��Center=��� -	   $
 txtTotalProjects��$��Poppins)�$
��Bold"�$��20(����#333$��Center=��� $��2�����#E8F6EF$ 15��$��32,10,10,10q�$ 20q����#6BCB77$��1q�._��� .+��� $��/Assets/profits.png��$��50��$��50��$��Center=��� $��Poppins)�$��Total Income (LKR)��$��SemiBold"�$��12(�$��0,10,0,5q�$��Center=��� -
   $
 txtTotalIncome��$��Poppins)�$
��Bold"�$��20(����#333$��Center=��� $��3�����#E6F0FF$ 15��$��10,10,17,10q�$ 20q����#4D96FF$��1q�._��� .+��� $��/Assets/rating.png��$��50��$��50��$��Center=��� $��Poppins)�$��Reviews��$��SemiBold"�$��12(�$��0,10,0,5q�$��Center=��� -   $
 txtPendingReviews��$��Poppins)�$
��Bold"�$��20(����#333$��Center=�� $	��357�� �� �� .+��� 
�������$��10q�$ 10q�$ 10�����#DDD$��1q�$��0��._��� .+��� $$��Monthly Income (Last 6 Months)��$
��Bold"�$��0,0,0,10q�$��Poppins)�#   LiveCharts.Wpf.CartesianChart  $	��280��$	��268��&    LiveCharts.Wpf.Charts.Base.Chart   Series �� *IncomeSeriesCollection+   AxisX    LiveCharts.Wpf.Axis     Title$ Months��   Labels �� *IncomeLabels+   AxisY   $ Income (LKR)��   LabelFormatter �� *	Formatter+�� 
�������$��10q�$ 10q�$ 10�����#DDD$��1q�$��1��._��� .+��� $��Project Status��$
��Bold"�$��0,0,0,10q�$��Poppins)�   LiveCharts.Wpf.PieChart  -     Name$ ProjectPieChart��$	��280��� $��1��
������ .+�� $��20q� � RowDefinitions �� $	��78* ��� $	��77* �.+��� 
�������$��10,10,10,10q�$ 10q�$ 10�����#DDD$��1q�$��0��._��� .+��� $��Calendar��$
��Bold"�$��0,0,0,10q�$��Poppins)�$��16(����#111827&   System.Windows.Controls.Calendar  $	��200��$	��250�����#E0E0E0$��1q����#F9FAFB���#111827$��Poppins)� � 	Resources :  4System.Windows.Controls.Primitives.CalendarDayButton �� 
TargetType �� Property �� Value �� 
TargetType A�Name �� Triggers P� Property P� Value �� 
TargetName��%�  '        �� "  .���  � ��
 ���� ��  � ��
 ���� ��  � �� �#111827��  � ��$ 12(���  � ��$ Center=���  � ��$ Center=���  � �� �� "  .R�� .+�A� $ circle��
������ $��30��$��30��$��Center=�$��Center=��� $��Center=�$��Center=� P�  �@ IsToday$
 True��. ��� $ circle�� � �� �#FACC15��  � ��
 �   �P�  �@ 
IsSelected$
 True��. ��� $ circle�� � �� �#111827��  � ��
 �����P�  �@J�IsMouseOver$
 True��. ��� $ circle�� � �� �#E5E7EBP�  � {�$ False��. ���  � �� �#9CA3AF�� ���#FFF8E1$��10,10,10,-18q�$ 20q�$ 15�����#F9D342$��1q�$��1��._��� -    ��Name$ ReviewsStackPanel��.+��� $��Recent Customer Reviews��$
��Bold"�$��0,0,0,10q�$��Poppins)�$��16(����#F9D342�� ���� *RecentReviews+���� .R��� $��5q�$ 10q�$ 15��$��1q����� *BorderColor+���� *BackgroundColor+._��� .+��� $
��Bold"�$��14(����� *CustomerName+���� *BorderColor+�� $��12(����#666���� *	Content+