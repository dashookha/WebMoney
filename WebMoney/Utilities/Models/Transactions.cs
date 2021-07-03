using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMoney.Utilities.Models {
	public partial class Transactions : IEntity {
		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		public DateTime Datetime { get; set; } //���� ����������
		public double Amount { get; set; } //����� � ������ ����������
		//true ����������   false   �����������
		public bool Movement { get; set; } //�������� �� ����� � ������ �����
		public double RemainingAmount { get; set; } //����� ������� � ������ ����� ����������
		public string Description { get; set; } //������ (�������� ����������)
		public string Channel { get; set; } //�����, ����� ������� ���� ����������� �������� � ��� ��������������
		[ForeignKey("Accounts")]
		public int Account_Id { get; set; }
		[ForeignKey("Currency")]
		public int Currency_Id { get; set; }
		[ForeignKey("Categories")]
		public int Category_Id { get; set; }

		public virtual Accounts Accounts { get; set; }
		public virtual Categories Categories { get; set; }
		public virtual Currency Currency { get; set; }
	}
}


/*
<statements status="excellent" credit="0.0" @*����� �����������*@ debet="0.3" @*����� ����������*@>
	<statement card="5168742060221193" @*����� �����*@
			   appcode="591969"
			   trandate="2013-09-02" @*���� ����������*@
			   amount="0.10 UAH" @*����� � ������ ����������*@
			   cardamount="-0.10 UAH" @*�������� �� ����� � ������ �����*@
			   rest="0.95 UAH" @*����� ������� � ������ ����� ����������*@
			   terminal="���������� ���������� +380139917053 ����� �������24�" @*�����, ����� ������� ���� ����������� �������� � ��� ��������������*@
			   description="" /> @*������ (�������� ����������)*@
		</statements>
*/