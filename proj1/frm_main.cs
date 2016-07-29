using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proj1 {
	public partial class frm_main : Form {
		string nomeJg1, nomeJg2, jogada, letraJg1, letraJg2, nX = "", nO = "";
		int cont = 0, pontoJg1 = 0, pontoJg2 = 0, empates = 0, cpujoga = 0, estiloJogo = 0;

		public frm_main() {
			InitializeComponent();
			limpar(0); // 0 pra limpar tudo
			tx_jg1.Focus();
		}



		private void frm_main_FormClosing(object sender, FormClosingEventArgs e) {
			if (MessageBox.Show("Deseja fechar o Jogo da Velha?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No) {
				e.Cancel = true;
			}
		}

		private void bt_sair_Click(object sender, EventArgs e) {
			Close();
		}

		public void jogada_artificial() {
			if (cpujoga == 1) {
				if (bt1.Enabled == true) {
					Button bt = (Button)bt1;
					trocaLetra(bt);
					return;
				}

				if (bt2.Enabled == false && bt7.Enabled == true) {
					Button bt = (Button)bt7;
					trocaLetra(bt);
					estiloJogo = 1;
					return;
				} else if (bt3.Enabled == false && bt7.Enabled == true) {
					Button bt = (Button)bt7;
					trocaLetra(bt);
					estiloJogo = 2;
					return;
				} else if (bt3.Enabled == false && bt9.Enabled == true) {
					Button bt = (Button)bt9;
					trocaLetra(bt);
					estiloJogo = 3;
					return;
				} else if (bt4.Enabled == false && bt3.Enabled == true) {
					Button bt = (Button)bt3;
					trocaLetra(bt);
					estiloJogo = 4;
					return;
				} else if (bt5.Enabled == false && bt9.Enabled == true) {
					Button bt = (Button)bt9;
					trocaLetra(bt);
					estiloJogo = 5;
					return;
				} else if (bt6.Enabled == false && bt3.Enabled == true) {
					Button bt = (Button)bt3;
					trocaLetra(bt);
					estiloJogo = 6;
					return;
				} else if (bt7.Enabled == false && bt3.Enabled == true) {
					Button bt = (Button)bt3;
					trocaLetra(bt);
					estiloJogo = 7;
					return;
				} else if (bt8.Enabled == false && bt3.Enabled == true) {
					Button bt = (Button)bt3;
					trocaLetra(bt);
					estiloJogo = 8;
					return;
				} else if (bt8.Enabled == false && bt7.Enabled == true) {
					// A e B
					Button bt = (Button)bt7;
					trocaLetra(bt);
					estiloJogo = 9;
					return;
				} else if (bt9.Enabled == false && bt3.Enabled == true) {
					Button bt = (Button)bt3;
					trocaLetra(bt);
					estiloJogo = 10;
					return;
				}
			}
		}

		public void trocaLetra(Button bt) {
			bt.Text = jogada;
			if (jogada == "X") {
				jogada = "O";
				rb_o.Checked = true;
				//lb_who.Text = "Vez de " + nO;
			} else {
				jogada = "X";
				rb_x.Checked = true;
				//lb_who.Text = "Vez de " + nX;
			}
			wholabel_change();
			bt.Enabled = false;
			cont++;
			gb_jogadores.Focus();
			vencedor();
		}

		public void vencedor() {
			if (cont >= 5) {
				/// Verifica se O ganhou
				if (
					// Linhas Horizontais
					(bt1.Text == "O") && (bt2.Text == "O") && (bt3.Text == "O") ||
					(bt4.Text == "O") && (bt5.Text == "O") && (bt6.Text == "O") ||
					(bt7.Text == "O") && (bt8.Text == "O") && (bt9.Text == "O") ||
					// Linhas Verticas
					(bt1.Text == "O") && (bt4.Text == "O") && (bt7.Text == "O") ||
					(bt2.Text == "O") && (bt5.Text == "O") && (bt8.Text == "O") ||
					(bt3.Text == "O") && (bt6.Text == "O") && (bt9.Text == "O") ||
					// Diagonais
					(bt1.Text == "O") && (bt5.Text == "O") && (bt9.Text == "O") ||
					(bt3.Text == "O") && (bt5.Text == "O") && (bt7.Text == "O")
				   ) {
					if (letraJg1 == "O") {
						MessageBox.Show(nomeJg1 + " Venceu!", "Parabéns", MessageBoxButtons.OK);
						pontoJg1++;
						rb_o.Checked = true;
						jogada = "O";
					} else if (letraJg2 == "O") {
						MessageBox.Show(nomeJg2 + " Venceu!", "Parabéns", MessageBoxButtons.OK);
						pontoJg2++;
						rb_o.Checked = true;
						jogada = "O";
					}
					atualiza_placar();
					limpar(1);	//1 pra limpar só botões e contador
					habilita_btns(1);
				}
				/// Verifica se X ganhou
				if (
					// Linhas Horizontais
					(bt1.Text == "X") && (bt2.Text == "X") && (bt3.Text == "X") ||
					(bt4.Text == "X") && (bt5.Text == "X") && (bt6.Text == "X") ||
					(bt7.Text == "X") && (bt8.Text == "X") && (bt9.Text == "X") ||
					// Linhas Verticas
					(bt1.Text == "X") && (bt4.Text == "X") && (bt7.Text == "X") ||
					(bt2.Text == "X") && (bt5.Text == "X") && (bt8.Text == "X") ||
					(bt3.Text == "X") && (bt6.Text == "X") && (bt9.Text == "X") ||
					// Diagonais
					(bt1.Text == "X") && (bt5.Text == "X") && (bt9.Text == "X") ||
					(bt3.Text == "X") && (bt5.Text == "X") && (bt7.Text == "X")
				   ) {
					if (letraJg1 == "X") {
						MessageBox.Show(nomeJg1 + " Venceu!", "Parabéns", MessageBoxButtons.OK);
						pontoJg1++;
						rb_x.Checked = true;
						jogada = "X";
					} else if (letraJg2 == "X") {
						MessageBox.Show(nomeJg2 + " Venceu!", "Parabéns", MessageBoxButtons.OK);
						pontoJg2++;
						rb_x.Checked = true;
						jogada = "X";
					}
					atualiza_placar();
					limpar(1);	//1 pra limpar só botões e contador
					habilita_btns(1);
				}
				/// Verifica se empatou
				if(cont == 9){
					MessageBox.Show("Empate!", "Poxa, deu velha :(", MessageBoxButtons.OK);
					empates++;
					atualiza_placar();
					limpar(1);	//1 pra limpar só botões e contador
					habilita_btns(1);
				}
			}
		}

		public void limpar(int identificador) {
			bt1.Text = "";
			bt2.Text = "";
			bt3.Text = "";
			bt4.Text = "";
			bt5.Text = "";
			bt6.Text = "";
			bt7.Text = "";
			bt8.Text = "";
			bt9.Text = "";
			lb_who.Text = "";
			cont = 0;

			if (identificador == 0) {
				tx_jg1.Text = "";
				tx_jg2.Text = "";
				lb_jg1.Text = "";
				lb_jg2.Text = "";
				lb_empate.Text = "";
				lb_placar1.Text = "";
				lb_placar2.Text = "";
				lb_who.Text = "";

				letraJg1 = "";
				letraJg2 = "";

				pontoJg1 = 0;
				pontoJg2 = 0;
				empates = 0;
			}
		}

		public void habilita_btns(int identificador) {
			bt1.Enabled = true;
			bt2.Enabled = true;
			bt3.Enabled = true;
			bt4.Enabled = true;
			bt5.Enabled = true;
			bt6.Enabled = true;
			bt7.Enabled = true;
			bt8.Enabled = true;
			bt9.Enabled = true;

			if (identificador == 0) {
				bt_iniciar.Enabled = true;
				bt_cpu.Enabled = true;
				tx_jg1.Visible = true;
				tx_jg2.Visible = true;
				gb_opcoes.Enabled = true;
				pn_btns.Enabled = false;
				rb_x.Checked = true;

				lb_who.Text = "";
				tx_jg2.Text = "";
				tx_jg2.Visible = true;
				bt_cpu.Text = "Contra CPU";
				cpujoga = 0;
			}
			wholabel_change();
		}

		public void atualiza_placar() {
			string t1, t2, t3;
			if(pontoJg1 > 1){
				t1	= " Vitórias";
			}else{
				t1	= " Vitória";
			}
			if (pontoJg2 > 1) {
				t2 = " Vitórias";
			} else {
				t2 = " Vitória";
			}
			if (empates > 1) {
				t3 = " Empates";
			} else {
				t3 = " Empate";
			}

			lb_placar1.Text = pontoJg1.ToString() + t1;
			lb_placar2.Text = pontoJg2.ToString() + t2;
			lb_empate.Text = empates.ToString() + t3;

			wholabel_change();
		}

		public void wholabel_change() {
			if (cont < 8) {	
				if (letraJg1 == "X") {
					nX = nomeJg1;
					nO = nomeJg2;
				} else {
					nX = nomeJg2;
					nO = nomeJg1;
				}
				if (rb_x.Checked == true) {
					lb_who.Text = "Vez de " + nX;
				} else {
					lb_who.Text = "Vez de " + nO;
				}
			}
		}

		private void bt_iniciar_Click(object sender, EventArgs e) {
			nomeJg1 = tx_jg1.Text;
			nomeJg2 = tx_jg2.Text;
			if (nomeJg1 == "" || nomeJg2 == "") {
				MessageBox.Show("Digite os nomes dos jogadores.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				if (nomeJg1 == "") {
					tx_jg1.Focus();
				} else {
					tx_jg2.Focus();
				}
				//Application.ExitThread();
				return;
			}

			tx_jg1.Visible = false;
			lb_jg1.Text = nomeJg1 + " - Joga com ";

			tx_jg2.Visible = false;
			lb_jg2.Text = nomeJg2 + " - Joga com ";

			lb_who.Visible = true;

			if (rb_x.Checked) {
				lb_jg1.Text = lb_jg1.Text + "X";
				lb_jg2.Text = lb_jg2.Text + "O";
				letraJg1 = "X";
				letraJg2 = "O";
			} else {
				lb_jg1.Text = lb_jg1.Text + "O";
				lb_jg2.Text = lb_jg2.Text + "X";
				letraJg1 = "O";
				letraJg2 = "X";
			}

			atualiza_placar();
			//wholabel_change();
			jogada = "X";
			rb_x.Checked = true;
			gb_opcoes.Enabled = false;
			bt_iniciar.Enabled = false;
			bt_cpu.Enabled = false;
			pn_btns.Enabled = true;
		}

		private void bt_reiniciar_Click(object sender, EventArgs e) {
			limpar(0);	// 0 pra limpar tudo
			habilita_btns(0);
			lb_who.Visible = false;
		}

		private void bt_cpu_Click(object sender, EventArgs e) {
			if (cpujoga == 0) {
				tx_jg2.Text = "CPU";
				tx_jg2.Visible = false;
				bt_cpu.Text = "Contra 2";
				cpujoga++;
			} else if (cpujoga == 1) {
				tx_jg2.Text = "";
				tx_jg2.Visible = true;
				bt_cpu.Text = "Contra CPU";
				cpujoga = 0;
			}
		}

		private void bt1_Click(object sender, EventArgs e) {
			//bt1.Text = jogada;
			Button bt = (Button)sender;
			trocaLetra(bt);
			jogada_artificial();
		}

		private void bt2_Click(object sender, EventArgs e) {
			//bt2.Text = jogada;
			Button bt = (Button)sender;
			trocaLetra(bt);
			jogada_artificial();
		}

		private void bt3_Click(object sender, EventArgs e) {
			//bt3.Text = jogada;
			Button bt = (Button)sender;
			trocaLetra(bt);
			jogada_artificial();
		}

		private void bt4_Click(object sender, EventArgs e) {
			//bt4.Text = jogada;
			Button bt = (Button)sender;
			trocaLetra(bt);
			jogada_artificial();
		}

		private void bt5_Click(object sender, EventArgs e) {
			//bt5.Text = jogada;
			Button bt = (Button)sender;
			trocaLetra(bt);
			jogada_artificial();
		}

		private void bt6_Click(object sender, EventArgs e) {
			//bt6.Text = jogada;
			Button bt = (Button)sender;
			trocaLetra(bt);
			jogada_artificial();
		}

		private void bt7_Click(object sender, EventArgs e) {
			//bt7.Text = jogada;
			Button bt = (Button)sender;
			trocaLetra(bt);
			jogada_artificial();
		}

		private void bt8_Click(object sender, EventArgs e) {
			//bt8.Text = jogada;
			Button bt = (Button)sender;
			trocaLetra(bt);
			jogada_artificial();
		}

		private void bt9_Click(object sender, EventArgs e) {
			//bt9.Text = jogada;
			Button bt = (Button)sender;
			trocaLetra(bt);
			jogada_artificial();
		}

	}
}
