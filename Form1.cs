using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        //a few global variables

        FileStream fs;
        string filename = null;
        SoundPlayer sp;
        string current_filename = null;
        int duration = 0;
        double amplitude = 0;
        double frequency = 0;
        bool is_playing = false;

        private void Create_button_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;

            duration_field.Visible = true;
            frequency_field.Visible = true;
            amplitude_field.Visible = true;
            filename_field.Visible = true;

            Done_button.Visible = true;

            if (duration_field.Text != null
                && frequency_field.Text != null
                && amplitude_field.Text != null
                && filename_field.Text != null)
                Done_button.Enabled = true;
        }

        private void Play_button_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer(current_filename);
            if (is_playing)
            {
                sp.Stop();
                is_playing = false;
            }
            else
            {
                sp.PlayLooping();
                is_playing = true;
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            wavfile_read wav = new wavfile_read();
            wav.read_wavefile(fs);
        }

        private void C_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Wave File (*.wav)|*.wav;";
            if (open.ShowDialog() != DialogResult.OK) return;
            filename = open.FileName;
            Play_Button_2.Enabled = true;
        }

        private void Play_Button_2_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer(filename);
            sp.Play();
            Play_Button_2.Enabled = false;
            Pause_button_2.Enabled = true;
        }
        private void Pause_button_2_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer(filename);
            sp.Stop();
            Pause_button_2.Enabled = false;
            Play_Button_2.Enabled = true;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        { }

        private void Done_button_Click(object sender, EventArgs e)
        {
            duration = Int32.Parse(duration_field.Text) * 44100;
            frequency = Double.Parse(frequency_field.Text);
            amplitude = Double.Parse(amplitude_field.Text) + 1;
            current_filename = filename_field.Text + ".wav";

            wavfile_create wave_c = new wavfile_create();
            wave_c.wavefile_create(amplitude, duration, frequency, current_filename);

            MessageBox.Show("Congratulations! \n You have created a .wav file");
            Play_button.Enabled = true;
        }
    }
    public abstract class wavfile
    {

    }

    public abstract class waveform : wavfile
    {

    }
    public class wavfile_read : wavfile
    {
        public void read_wavefile(FileStream fs)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Wave File (*.wav)|*.wav;";
            if (open.ShowDialog() != DialogResult.OK) return;

            fs = File.Open(open.FileName, FileMode.Open);
            BinaryReader r = new BinaryReader(fs);

            wavfile_header fs_h = new wavfile_header();

            //reading header

            //chunk
            fs_h.riff_tag = r.ReadString();
            fs_h.riff_length = r.ReadInt32();
            fs_h.wave_tag = r.ReadString();

            //subchunk 1
            fs_h.fmt_tag = r.ReadString();
            fs_h.fmt_length = r.ReadInt32();

            fs_h.audio_format = r.ReadInt16();
            fs_h.num_channels = r.ReadInt16();

            fs_h.sample_rate = r.ReadInt32();
            fs_h.byte_rate = r.ReadInt32();

            fs_h.block_align = r.ReadInt16();
            fs_h.bits_per_sample = r.ReadInt16();

            if (fs_h.data_length == 18)
            {
                fs_h.fmt_extra_size = r.ReadInt16();
                r.ReadBytes(fs_h.fmt_extra_size);
            }

            //subchunk 2

            fs_h.data_tag = r.ReadString();
            fs_h.bytes = r.ReadInt32();

            wavfile_waveform wave = new wavfile_waveform();
            wave.read_waveform(fs, fs_h, r, wave.L, wave.R);
        }
    }

    public class wavfile_create : wavfile
    {
        public void wavefile_create(double amplitude, int duration, double frequency, string file_name)
        {
            byte[] getBytes(string text)
            {
                byte[] enc_byte = Encoding.ASCII.GetBytes(text);
                return enc_byte;
            }
            //Creating a header
            wavfile_header header = new wavfile_header();
            header.fmt_length = 16;
            header.audio_format = 1;
            header.bits_per_sample = 16;
            header.num_channels = 1;
            header.sample_rate = 44100;
            header.byte_rate = header.sample_rate * header.num_channels * (header.bits_per_sample / 8);
            header.num_samples = duration;
            header.block_align = (short)(header.num_channels * (header.bits_per_sample / 8));
            header.data_length = header.num_samples * header.num_channels * (header.bits_per_sample / 8);
            header.riff_length = 4 + 16 + header.fmt_length + header.data_length;
            header.riff_tag = "RIFF";
            header.wave_tag = "WAVE";
            header.fmt_tag = "fmt ";
            header.data_tag = "data";

            if (file_name != null)
                File.Delete(file_name);

            FileStream f = new FileStream(file_name, FileMode.Create);
            BinaryWriter wr = new BinaryWriter(f);

            wr.Write(getBytes("RIFF"));
            wr.Write(header.riff_length);
            wr.Write(getBytes("WAVE"));
            wr.Write(getBytes("fmt "));
            wr.Write(header.fmt_length);
            wr.Write(header.audio_format);
            wr.Write(header.num_channels);
            wr.Write(header.sample_rate);
            wr.Write(header.byte_rate);
            wr.Write(header.block_align);
            wr.Write(header.bits_per_sample);
            wr.Write(getBytes("data"));
            wr.Write(header.data_length);

            // creating a waveform
            wavfile_waveform my_file = new wavfile_waveform();
            my_file.waveform_create(wr, amplitude, duration, frequency, file_name);
        }
    }
    class wavfile_header : wavfile
    {
        public string riff_tag;
        public int riff_length;
        public string wave_tag;
        public string fmt_tag;
        public int fmt_length;
        public short audio_format;
        public short num_channels;
        public int sample_rate;
        public int byte_rate;
        public short block_align;
        public short bits_per_sample;
        public string data_tag;
        public int data_length;
        public int bytes;
        public int bytes_per_sample;
        public int n_values;
        public int fmt_extra_size;
        public int num_samples;
    }
    
    class waveform_extend : waveform
    {
        public void extend(double amplitude, int duration, double frequency, string file_name, double[] waveform_1, double[] waveform_2)
        {
            byte[] getBytes(string text)
            {
                byte[] enc_byte = Encoding.ASCII.GetBytes(text);
                return enc_byte;
            }
            //Creating a header
            wavfile_header header = new wavfile_header();
            header.fmt_length = 16;
            header.audio_format = 1;
            header.bits_per_sample = 16;
            header.num_channels = 1;
            header.sample_rate = 44100;
            header.byte_rate = header.sample_rate * header.num_channels * (header.bits_per_sample / 8);
            header.num_samples = duration;
            header.block_align = (short)(header.num_channels * (header.bits_per_sample / 8));
            header.data_length = header.num_samples * header.num_channels * (header.bits_per_sample / 8);
            header.riff_length = 4 + 16 + header.fmt_length + header.data_length;
            header.riff_tag = "RIFF";
            header.wave_tag = "WAVE";
            header.fmt_tag = "fmt ";
            header.data_tag = "data";

            if (file_name != null)
                File.Delete(file_name);

            FileStream f = new FileStream(file_name, FileMode.Create);
            BinaryWriter wr = new BinaryWriter(f);

            wr.Write(getBytes("RIFF"));
            wr.Write(header.riff_length);
            wr.Write(getBytes("WAVE"));
            wr.Write(getBytes("fmt "));
            wr.Write(header.fmt_length);
            wr.Write(header.audio_format);
            wr.Write(header.num_channels);
            wr.Write(header.sample_rate);
            wr.Write(header.byte_rate);
            wr.Write(header.block_align);
            wr.Write(header.bits_per_sample);
            wr.Write(getBytes("data"));
            wr.Write(header.data_length);

            //right channel / mono channel
            double[] waveform_pom_1 = new double[duration];
            double[] waveform_pom_2 = new double[duration];
            amplitude /= 2;

            for (int i = 0; i < duration; i++)
            {
                double t = (double)i / 44100;
                wr.Write((byte)(waveform_1[i] / 2 + amplitude * Math.Sin(Math.PI * frequency * t)));
                waveform_pom_1[i] = (waveform_1[i] / 2 + amplitude * Math.Sin(Math.PI * frequency * t));
                wr.Write((byte)(waveform_2[i] / 2 + amplitude * Math.Sin(Math.PI * frequency * t++)));
                waveform_pom_2[i] = (waveform_2[i] / 2 + amplitude * Math.Sin(Math.PI * frequency * t++));
            }

            wr.Close();
            wr.Dispose();

            DialogResult new_message = MessageBox.Show("would You like to add another waveform?", "Extending the file with other components", MessageBoxButtons.YesNo);
            if (new_message == DialogResult.Yes)
            {
                double new_freq = double.Parse(my_popup.ShowDialog("Frequency", "Adding frequency"));
                waveform_extend ext = new waveform_extend();
                ext.extend(amplitude, duration, new_freq, file_name, waveform_pom_1, waveform_pom_2);
            }
            else if (new_message == DialogResult.No) { }
        }
    }
    class wavfile_waveform : waveform
    {
        public float[] L;
        public float[] R;

        public bool read_waveform(FileStream fs, wavfile_header fs_h, BinaryReader r, float[] L, float[] R)
        {
            L = R = null;

            //Collecting data

            byte[] byte_array = r.ReadBytes(fs_h.bytes);

            fs_h.bytes_per_sample = fs_h.bits_per_sample / 8;
            fs_h.n_values = fs_h.bytes / fs_h.bytes_per_sample;


            float[] my_float = null;
            switch (fs_h.bits_per_sample)
            {
                case 64:
                    double[] my_double = new double[fs_h.n_values];
                    Buffer.BlockCopy(byte_array, 0, my_double, 0, fs_h.bytes);
                    my_float = Array.ConvertAll(my_double, e => (float)e);
                    break;
                case 32:
                    my_float = new float[fs_h.n_values];
                    Buffer.BlockCopy(byte_array, 0, my_float, 0, fs_h.bytes);
                    break;
                case 16:
                    Int16[] my_Int_16 = new Int16[fs_h.n_values];
                    Buffer.BlockCopy(byte_array, 0, my_Int_16, 0, fs_h.bytes);
                    my_float = Array.ConvertAll(my_Int_16, e => e / (float)(Int16.MaxValue + 1));
                    break;
                default:
                    return false;
            }

            switch (fs_h.num_channels)
            {
                case 1:
                    L = my_float;
                    R = null;
                    return true;
                case 2:
                    int n_samples = fs_h.n_values / 2;
                    L = new float[n_samples];
                    R = new float[n_samples];

                    for (int i = 0, v = 0; i < n_samples; i++)
                    {
                        L[i] = my_float[v++];
                        R[i] = my_float[v++];
                    }
                    return true;
                case 3:
                    return false;
            }

            return false;
        }
        public void waveform_create(BinaryWriter br, double amp, int dur, double freq, string filename)
        {
            //right channel / mono channel
            double[] waveform1 = new double[dur];
            double[] waveform2 = new double[dur];
            for (int i = 0; i < dur; i++)
            {
                double t = (double)i / 44100;
                br.Write((byte)(amp * Math.Sin(Math.PI * freq * t)));
                waveform1[i] = (amp * Math.Sin(Math.PI * freq * t));
                br.Write((byte)(amp * Math.Sin(Math.PI * freq * t++)));
                waveform2[i] = (amp * Math.Sin(Math.PI * freq * t++));
            }

            br.Close();
            br.Dispose();

            DialogResult new_message = MessageBox.Show("would You like to add another waveform?", "Extending the file with other components", MessageBoxButtons.YesNo);
            if (new_message == DialogResult.Yes)
            {
                double new_freq = double.Parse(my_popup.ShowDialog("Frequency", "Adding frequency"));
                waveform_extend ext = new waveform_extend();
                ext.extend(amp, dur, new_freq, filename, waveform1, waveform2);
            }
            else if (new_message == DialogResult.No) {}
        }

    }
    public static class my_popup
    {
        public static string ShowDialog(string text, string caption)
        {
            Form my_popup = new Form()
            {
                Width = 200,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 25, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 25, Top = 50, Width = 150 };
            Button confirmation = new Button() { Text = "Done", Left = 50, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { my_popup.Close(); };
            my_popup.Controls.Add(textBox);
            my_popup.Controls.Add(confirmation);
            my_popup.Controls.Add(textLabel);
            my_popup.AcceptButton = confirmation;

            return my_popup.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
