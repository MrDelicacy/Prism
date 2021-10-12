using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;



namespace Tabitems
{


    public class Order : INotifyPropertyChanged
    {
        //id заказа
        public int Id { get; set; }

        //информация о заказе
        public OrderInfo orderInfo { get; set;}

        //данные на вкладке
        private string orderHeader;
        public string OrderHeader
        {
            get { return orderHeader; }
            set
            {
                orderHeader = value;
                OnPropertyChanged("OrderHeader");
            }
        }




        //список названий миксов
        public List<string> mixesName { get; set; }

        //коллекция итерций
        public ObservableCollection<Iteration> iterations { get; set; }
        //выбранная итерация
        private Iteration selectedIteration;
        public Iteration SelectedIteration
        {
            get { return selectedIteration; }
            set
            {
                selectedIteration = value;
                OnPropertyChanged("SelectedIteration");
            }
        }

        private int iterationCount;
        public int IterationCount
        {
            get { return iterationCount; }
            set 
            { 
                iterationCount = value;
                OnPropertyChanged("IterationCount");
            }
        }


        //переменная, которая показывает, внесены ли изменения в список итераций
        public bool currentChanges;


        //коллекция информации о расчетной и реальной массе краски для каждой итерации
        public List<EstimatedAndRealWeight> estAndReal { get; set; }



        private double m1;
        public double M1
        {
            get { return m1; }
            set
            {
                m1 = value;
                if (PercentCalculationOnOf == true)
                {
                    Notify?.Invoke("добавлен mix");
                    percentCalculation();
                    percentCalculation_();
                }
                OnPropertyChanged("M1");
            }
        }
        private double m2;
        public double M2
        {
            get { return m2; }
            set
            {
                m2 = value;
                if (PercentCalculationOnOf == true)
                {
                    Notify?.Invoke("добавлен mix");
                    percentCalculation();
                    percentCalculation_();
                }
                OnPropertyChanged("M2");
            }
        }
        private double m3;
        public double M3
        {
            get { return m3; }
            set
            {
                m3 = value;
                if (PercentCalculationOnOf == true)
                {
                    Notify?.Invoke("добавлен mix");
                    percentCalculation();
                    percentCalculation_();
                }
                OnPropertyChanged("M3");
            }
        }
        private double m4;
        public double M4
        {
            get { return m4; }
            set
            {
                m4 = value;
                if (PercentCalculationOnOf == true)
                {
                    Notify?.Invoke("добавлен mix");
                    percentCalculation();
                    percentCalculation_();
                }
                OnPropertyChanged("M4");
            }
        }
        private double m5;
        public double M5
        {
            get { return m5; }
            set
            {
                m5 = value;
                if (PercentCalculationOnOf == true)
                {
                    Notify?.Invoke("добавлен mix");
                    percentCalculation();
                    percentCalculation_();
                }
                OnPropertyChanged("M5");
            }
        }
        private double m6;
        public double M6
        {
            get { return m6; }
            set
            {
                m6 = value;
                if (PercentCalculationOnOf == true)
                {
                    Notify?.Invoke("добавлен mix");
                    percentCalculation();
                    percentCalculation_();
                }
                OnPropertyChanged("M6");
            }
        }
        private double m7;
        public double M7
        {
            get { return m7; }
            set
            {
                m7 = value;
                if (PercentCalculationOnOf == true)
                {
                    Notify?.Invoke("добавлен mix");
                    percentCalculation();
                    percentCalculation_();
                }
                OnPropertyChanged("M7");
            }
        }
        private double m8;
        public double M8
        {
            get { return m8; }
            set
            {
                m8 = value;
                if (PercentCalculationOnOf == true)
                {
                    Notify?.Invoke("добавлен mix");
                    percentCalculation();
                    percentCalculation_();
                }
                OnPropertyChanged("M8");
            }
        }
        private double m9;
        public double M9
        {
            get { return m9; }
            set
            {
                m9 = value;
                if (PercentCalculationOnOf == true)
                {
                    Notify?.Invoke("добавлен mix");
                    percentCalculation();
                    percentCalculation_();
                }
                OnPropertyChanged("M9");
            }
        }
        private double m10;
        public double M10
        {
            get { return m10; }
            set
            {
                m10 = value;
                if (PercentCalculationOnOf == true)
                {
                    Notify?.Invoke("добавлен mix");
                    percentCalculation();
                    percentCalculation_();
                }
                OnPropertyChanged("M10");
            }
        }
        private double m11;
        public double M11
        {
            get { return m11; }
            set
            {
                m11 = value;
                if (PercentCalculationOnOf == true)
                {
                    Notify?.Invoke("добавлен mix");
                    percentCalculation();
                    percentCalculation_();
                }
                OnPropertyChanged("M11");
            }
        }
        private double m12;
        public double M12
        {
            get { return m12; }
            set
            {
                m12 = value;
                if (PercentCalculationOnOf == true)
                {
                    Notify?.Invoke("добавлен mix");
                    percentCalculation();
                    percentCalculation_();
                }
                OnPropertyChanged("M12");
            }
        }
        private double m13;
        public double M13
        {
            get { return m13; }
            set
            {
                m13 = value;
                if (PercentCalculationOnOf == true)
                {
                    Notify?.Invoke("добавлен mix");
                    percentCalculation();
                    percentCalculation_();
                }
                OnPropertyChanged("M13");
            }
        }
        private double m14;
        public double M14
        {
            get { return m14; }
            set
            {
                m14 = value;
                if (PercentCalculationOnOf == true)
                {
                    Notify?.Invoke("добавлен mix");
                    percentCalculation();
                    percentCalculation_();
                }
                OnPropertyChanged("M14");
            }
        }
        private double m15;
        public double M15
        {
            get { return m15; }
            set
            {
                m15 = value;
                if (PercentCalculationOnOf == true)
                {
                    Notify?.Invoke("добавлен mix");
                    percentCalculation();
                    percentCalculation_();
                }
                OnPropertyChanged("M15");
            }
        }
        private double m16;
        public double M16
        {
            get { return m16; }
            set
            {
                m16 = value;
                if (PercentCalculationOnOf == true)
                {
                    Notify?.Invoke("добавлен mix");
                    percentCalculation();
                    percentCalculation_();
                }
                OnPropertyChanged("M16");
            }
        }

        private double percentPointer1;
        public double PercentPointer1
        {
            get { return percentPointer1; }
            set
            {
                percentPointer1 = value;
                if (PercentCalculationOnOf == true)
                {
                    percentCalculation();
                }
                        OnPropertyChanged("PercentPointer1");
            }
        }
        private double pm1;
        public double Pm1
        {
            get { return pm1; }
            set
            {
                pm1 = value;
                OnPropertyChanged("Pm1");
            }
        }
        private double pm2;
        public double Pm2
        {
            get { return pm2; }
            set
            {
                pm2 = value;
                OnPropertyChanged("Pm2");
            }
        }
        private double pm3;
        public double Pm3
        {
            get { return pm3; }
            set
            {
                pm3 = value;
                OnPropertyChanged("Pm3");
            }
        }
        private double pm4;
        public double Pm4
        {
            get { return pm4; }
            set
            {
                pm4 = value;
                OnPropertyChanged("Pm4");
            }
        }

        private double pm5;
        public double Pm5
        {
            get { return pm5; }
            set
            {
                pm5 = value;
                OnPropertyChanged("Pm5");
            }
        }
        private double pm6;
        public double Pm6
        {
            get { return pm6; }
            set
            {
                pm6 = value;
                OnPropertyChanged("Pm6");
            }
        }
        private double pm7;
        public double Pm7
        {
            get { return pm7; }
            set
            {
                pm7 = value;
                OnPropertyChanged("Pm7");
            }
        }
        private double pm8;
        public double Pm8
        {
            get { return pm8; }
            set
            {
                pm8 = value;
                OnPropertyChanged("Pm8");
            }
        }
        private double pm9;
        public double Pm9
        {
            get { return pm9; }
            set
            {
                pm9 = value;
                OnPropertyChanged("Pm9");
            }
        }
        private double pm10;
        public double Pm10
        {
            get { return pm10; }
            set
            {
                pm10 = value;
                OnPropertyChanged("Pm10");
            }
        }
        private double pm11;
        public double Pm11
        {
            get { return pm11; }
            set
            {
                pm11 = value;
                OnPropertyChanged("Pm11");
            }
        }
        private double pm12;
        public double Pm12
        {
            get { return pm12; }
            set
            {
                pm12 = value;
                OnPropertyChanged("Pm12");
            }
        }
        private double pm13;
        public double Pm13
        {
            get { return pm13; }
            set
            {
                pm13 = value;
                OnPropertyChanged("Pm13");
            }
        }
        private double pm14;
        public double Pm14
        {
            get { return pm14; }
            set
            {
                pm14 = value;
                OnPropertyChanged("Pm14");
            }
        }
        private double pm15;
        public double Pm15
        {
            get { return pm15; }
            set
            {
                pm15 = value;
                OnPropertyChanged("Pm15");
            }
        }
        private double pm16;
        public double Pm16
        {
            get { return pm16; }
            set
            {
                pm16 = value;
                OnPropertyChanged("Pm16");
            }
        }


        
        private double percentPointer2;
        public double PercentPointer2
        {
            get { return percentPointer2; }
            set
            {
                percentPointer2 = value;
                if (PercentCalculationOnOf == true)
                {
                    percentCalculation_();
                }
                OnPropertyChanged("PercentPointer2");
            }
        }
        private double pm1_;
        public double Pm1_
        {
            get { return pm1_; }
            set
            {
                pm1_ = value;
                OnPropertyChanged("Pm1_");
            }
        }
        private double pm2_;
        public double Pm2_
        {
            get { return pm2_; }
            set
            {
                pm2_ = value;
                OnPropertyChanged("Pm2_");
            }
        }
        private double pm3_;
        public double Pm3_
        {
            get { return pm3_; }
            set
            {
                pm3_ = value;
                OnPropertyChanged("Pm3_");
            }
        }
        private double pm4_;
        public double Pm4_
        {
            get { return pm4_; }
            set
            {
                pm4_ = value;
                OnPropertyChanged("Pm4_");
            }
        }

        private double pm5_;
        public double Pm5_
        {
            get { return pm5_; }
            set
            {
                pm5_ = value;
                OnPropertyChanged("Pm5_");
            }
        }
        private double pm6_;
        public double Pm6_
        {
            get { return pm6_; }
            set
            {
                pm6_ = value;
                OnPropertyChanged("Pm6_");
            }
        }
        private double pm7_;
        public double Pm7_
        {
            get { return pm7_; }
            set
            {
                pm7_ = value;
                OnPropertyChanged("Pm7_");
            }
        }
        private double pm8_;
        public double Pm8_
        {
            get { return pm8_; }
            set
            {
                pm8_ = value;
                OnPropertyChanged("Pm8_");
            }
        }

        private double pm9_;
        public double Pm9_
        {
            get { return pm9_; }
            set
            {
                pm9_ = value;
                OnPropertyChanged("Pm9_");
            }
        }
        private double pm10_;
        public double Pm10_
        {
            get { return pm10_; }
            set
            {
                pm10_ = value;
                OnPropertyChanged("Pm10_");
            }
        }
        private double pm11_;
        public double Pm11_
        {
            get { return pm11_; }
            set
            {
                pm11_ = value;
                OnPropertyChanged("Pm11_");
            }
        }
        private double pm12_;
        public double Pm12_
        {
            get { return pm12_; }
            set
            {
                pm12_ = value;
                OnPropertyChanged("Pm12_");
            }
        }
        private double pm13_;
        public double Pm13_
        {
            get { return pm13_; }
            set
            {
                pm13_ = value;
                OnPropertyChanged("Pm13_");
            }
        }
        private double pm14_;
        public double Pm14_
        {
            get { return pm14_; }
            set
            {
                pm14_ = value;
                OnPropertyChanged("Pm14_");
            }
        }
        private double pm15_;
        public double Pm15_
        {
            get { return pm15_; }
            set
            {
                pm15_ = value;
                OnPropertyChanged("Pm15_");
            }
        }
        private double pm16_;
        public double Pm16_
        {
            get { return pm16_; }
            set
            {
                pm16_ = value;
                OnPropertyChanged("Pm16_");
            }
        }

        //Оповещение ViewModel о том что не нужно сохранять конфигурацию в базу данных
        public delegate void ConfigurateWorkProcess(string message);
        public event ConfigurateWorkProcess Notify;
        private bool percentCalculationOnOf;
        public bool PercentCalculationOnOf
        {
            set { percentCalculationOnOf = value; }
            get { return percentCalculationOnOf; }
        }

        //функция расчета пропорции компонентов
        public void percentCalculation()
        {
            SummAddMix = M1 + M2 + M3 + M4 + M5 + M6 + M7 + M8 + M9 + M10 + M11 + M12 + M13 + M14 + M15;
            double sum = SummAddMix;
            for (int i = 0; i < 15; i++)
                sum += afterTestMixes[i];
            ThickPaint = sum - SummAddMix;
            CurrentVolume = sum + afterTestMixes[15] + M16;
            for (int i = 0; i < 13; i++)
            {
                if (mixesName[i] == "177" || mixesName[i] == "199")
                    System.Windows.MessageBox.Show("Внимание! Под микс " + mixesName[i] + " зарезервирована отдельная ячейка.");
            }


            if (sum != 0)
            {
                Pm1 = (M1 + afterTestMixes[0]) / sum * PercentPointer1;
                Pm2 = (M2 + afterTestMixes[1]) / sum * PercentPointer1;
                Pm3 = (M3 + afterTestMixes[2]) / sum * PercentPointer1;
                Pm4 = (M4 + afterTestMixes[3]) / sum * PercentPointer1;
                Pm5 = (M5 + afterTestMixes[4]) / sum * PercentPointer1;
                Pm6 = (M6 + afterTestMixes[5]) / sum * PercentPointer1;
                Pm7 = (M7 + afterTestMixes[6]) / sum * PercentPointer1;
                Pm8 = (M8 + afterTestMixes[7]) / sum * PercentPointer1;
                Pm9 = (M9 + afterTestMixes[8]) / sum * PercentPointer1;
                Pm10 = (M10 + afterTestMixes[9]) / sum * PercentPointer1;
                Pm11 = (M11 + afterTestMixes[10]) / sum * PercentPointer1;
                Pm12 = (M12 + afterTestMixes[11]) / sum * PercentPointer1;
                Pm13 = (M13 + afterTestMixes[12]) / sum * PercentPointer1;
                Pm14 = (M14 + afterTestMixes[13]) / sum * PercentPointer1;
                Pm15 = (M15 + afterTestMixes[14]) / sum * PercentPointer1;
                Pm16 = (M16 + afterTestMixes[15]) / sum * PercentPointer1;

            }

        }


        //функция расчета пропорции компонентов без 177 и 199
        public void percentCalculation_()
        {
            double sum = M1 + M2 + M3 + M4 + M5 + M6 + M7 + M8 + M9 + M10 + M11 + M12 + M13;
            for (int i = 0; i < 13; i++)
                sum += afterTestMixes[i];

            if (sum != 0)
            {
                Pm1_ = (M1 + afterTestMixes[0]) / sum * PercentPointer2;
                Pm2_ = (M2 + afterTestMixes[1]) / sum * PercentPointer2;
                Pm3_ = (M3 + afterTestMixes[2]) / sum * PercentPointer2;
                Pm4_ = (M4 + afterTestMixes[3]) / sum * PercentPointer2;
                Pm5_ = (M5 + afterTestMixes[4]) / sum * PercentPointer2;
                Pm6_ = (M6 + afterTestMixes[5]) / sum * PercentPointer2;
                Pm7_ = (M7 + afterTestMixes[6]) / sum * PercentPointer2;
                Pm8_ = (M8 + afterTestMixes[7]) / sum * PercentPointer2;
                Pm9_ = (M9 + afterTestMixes[8]) / sum * PercentPointer2;
                Pm10_ = (M10 + afterTestMixes[9]) / sum * PercentPointer2;
                Pm11_ = (M11 + afterTestMixes[10]) / sum * PercentPointer2;
                Pm12_ = (M12 + afterTestMixes[11]) / sum * PercentPointer2;
                Pm13_ = (M13 + afterTestMixes[12]) / sum * PercentPointer2;
                Pm14_ = (M14 + afterTestMixes[13]) / sum * PercentPointer2;
                Pm15_ = (M15 + afterTestMixes[14]) / sum * PercentPointer2;
                Pm16_ = (M16 + afterTestMixes[15]) / (sum + afterTestMixes[13] + afterTestMixes[14] + M14 + M15) * PercentPointer2;
            }
        }





        //вес каждого микса после теста
        public ObservableCollection<double> afterTestMixes { get; set; }

        //сумма всех миксов после теста
        private double currentVolume;
        public double CurrentVolume
        {
            get { return currentVolume; }
            set
            {
                currentVolume = value;
                OnPropertyChanged("CurrentVolume");
            }
        }

        //вес каждого микса до теста
        public List<double> beforTestMixes { get; set; }

        private double beforeBrutto;
        public double BeforeBrutto
        {
            get { return beforeBrutto; }
            set
            {
                beforeBrutto = value;
                currentChanges = true;
                if (PercentCalculationOnOf == true)
                    Notify?.Invoke("добавлен mix");
                OnPropertyChanged("BeforeBrutto");
            }
        }
        private double afterBrutto;
        public double AfterBrutto
        {
            get { return afterBrutto; }
            set
            {
                afterBrutto = value;
                if(PercentCalculationOnOf==true)
                Notify?.Invoke("добавлен mix");
                TestCalc();
                OnPropertyChanged("AfterBrutto");
            }
        }

        //вес краски потраченной на тест
        private double test;
        public double Test
        {
            get { return test; }
            set
            {
                test = value;
                OnPropertyChanged("Test");
            }
        }

        //функция расчета веса краски потраченной на тест
        public void TestCalc()
        {
            Test = BeforeBrutto - AfterBrutto;
        }

        //сумма масс добавленных миксов
        private double summAddMix;
        public double SummAddMix
        {
            get { return summAddMix; }
            set
            {
                summAddMix = value;
                OnPropertyChanged("SummAddMix");
            }
        }


        //функция копирования данных в лист итераций
        public void CopyMixes()
        {

            Iteration it = new Iteration();
            it.setMix(mixesName[0], M1, Pm1, Pm1_);
            it.setMix(mixesName[1], M2, Pm2, Pm2_);
            it.setMix(mixesName[2], M3, Pm3, Pm3_);
            it.setMix(mixesName[3], M4, Pm4, Pm4_);
            it.setMix(mixesName[4], M5, Pm5, Pm5_);
            it.setMix(mixesName[5], M6, Pm6, Pm6_);
            it.setMix(mixesName[6], M7, Pm7, Pm7_);
            it.setMix(mixesName[7], M8, Pm8, Pm8_);
            it.setMix(mixesName[8], M9, Pm9, Pm9_);
            it.setMix(mixesName[9], M10, Pm10, Pm10_);
            it.setMix(mixesName[10], M11, Pm11, Pm11_);
            it.setMix(mixesName[11], M12, Pm12, Pm12_);
            it.setMix(mixesName[12], M13, Pm13, Pm13_);
            it.setMix(mixesName[13], M14, Pm14, Pm14_);
            it.setMix(mixesName[14], M15, Pm15, Pm15_);
            it.setMix(mixesName[15], M16, Pm16, Pm16_);
            it.iterationId = iterations.Count;
            iterations.Add(it);
            SelectedIteration = it;

        }

        //функция внесения данных в коллекцию информации о расчетной и реальной массе краски для каждой итерации
        public void AddToEstimatedAndRealWeight()
        {
            EstimatedAndRealWeight est = new EstimatedAndRealWeight();
            est.tare = Tare;
            if (BeforeBrutto != 0)
                est.realWeightBefore = BeforeBrutto;
            else
            {
                if (PlusTare == 0)
                    est.realWeightBefore = Tare + CurrentVolume;
                else
                    est.realWeightBefore = PlusTare + SummAddMix + M16;
            }
            if (AfterBrutto != 0)
                est.realWeightAfter = AfterBrutto;
            else
                est.realWeightAfter = est.realWeightBefore - Test;
            est.estimatedWeightBefore = CurrentVolume + Tare;
            est.estimatedWeightAfter = est.estimatedWeightBefore - Test;
            estAndReal.Add(est);
        }

        //функция расчета веса каждого микса до теста следующей итерации
        public void AddMixCalc()
        {
          //PercentCalculationOnOf = false;
            beforTestMixes[0] = afterTestMixes[0]+M1;
            M1 = 0;
            beforTestMixes[1] = afterTestMixes[1] + M2;
            M2 = 0;
            beforTestMixes[2] = afterTestMixes[2] + M3;
            M3 = 0;
            beforTestMixes[3] = afterTestMixes[3] + M4;
            M4 = 0;
            beforTestMixes[4] = afterTestMixes[4] + M5;
            M5 = 0;
            beforTestMixes[5] = afterTestMixes[5] + M6;
            M6 = 0;
            beforTestMixes[6] = afterTestMixes[6] + M7;
            M7 = 0;
            beforTestMixes[7] = afterTestMixes[7] + M8;
            M8 = 0;
            beforTestMixes[8] = afterTestMixes[8] + M9;
            M9 = 0;
            beforTestMixes[9] = afterTestMixes[9] + M10;
            M10 = 0;
            beforTestMixes[10] = afterTestMixes[10] + M11;
            M11 = 0;
            beforTestMixes[11] = afterTestMixes[11] + M12;
            M12 = 0;
            beforTestMixes[12] = afterTestMixes[12] + M13;
            M13 = 0;
            beforTestMixes[13] = afterTestMixes[13] + M14;
            M14 = 0;
            beforTestMixes[14] = afterTestMixes[14] + M15;
            M15 = 0;
            beforTestMixes[15] = afterTestMixes[15] + M16;
            M16 = 0;
            //считаем суммарный вес миксов до теста
            double summBefor = 0;
            for (int i = 0; i < 16; i++)
                summBefor += beforTestMixes[i];
            //считаем вес каждого микса после теста и сумму всех миксов
            double afterTestMixesSumm = 0;
            for (int i = 0; i < 16; i++)
            {
                afterTestMixes[i] = beforTestMixes[i] * (summBefor - Test) / summBefor;
                afterTestMixesSumm += afterTestMixes[i];
            }
            CurrentVolume = afterTestMixesSumm;
            //вносим вес каждого микса затраченного на тест
            for (int i = 0; i < SelectedIteration.mixes.Count; i++)
                SelectedIteration.mixes[i].TestWeight = beforTestMixes[i] - afterTestMixes[i];
            BeforeBrutto = 0;
            AfterBrutto = 0;
            percentCalculation();
            percentCalculation_();
            //PercentCalculationOnOf = true;
            OnPropertyChanged("afterTestMixes");
        }
       
        public void SubMixCalc(Iteration It)
        {
            double afterTestMixesSumm = 0;
            for (int i = 0; i < 16; i++)
            {
                beforTestMixes[i] = afterTestMixes[i]+It.mixes[i].TestWeight;
                afterTestMixes[i] = beforTestMixes[i] - It.mixes[i].MixAdd;
                afterTestMixesSumm += afterTestMixes[i];
            }
            M1 = It.mixes[0].MixAdd;
            M2 = It.mixes[1].MixAdd;
            M3 = It.mixes[2].MixAdd;
            M4 = It.mixes[3].MixAdd;
            M5 = It.mixes[4].MixAdd;
            M6 = It.mixes[5].MixAdd;
            M7 = It.mixes[6].MixAdd;
            M8 = It.mixes[7].MixAdd;
            M9 = It.mixes[8].MixAdd;
            M10 = It.mixes[9].MixAdd;
            M11 = It.mixes[10].MixAdd;
            M12 = It.mixes[11].MixAdd;
            M13 = It.mixes[12].MixAdd;
            M14 = It.mixes[13].MixAdd;
            M15 = It.mixes[14].MixAdd;
            M16 = It.mixes[15].MixAdd;

            CurrentVolume = afterTestMixesSumm;
            PlusTare = CurrentVolume + Tare;
            percentCalculation();
            percentCalculation_();
            OnPropertyChanged("afterTestMixes");

        }

        //функция установки значения в "брутто до"
        public void AddToPrevious()
        {
            if (PlusTare == 0)
                BeforeBrutto = Tare + CurrentVolume;
            else
                BeforeBrutto = PlusTare+ SummAddMix+M16;
        }

        //тара + вес всей смеси предыдущей итерации
        private double plusTare;
        public double PlusTare
        {
            get { return plusTare; }
            set
            {
                plusTare = value;
                OnPropertyChanged("PlusTare");
            }
        }

        //тара
        private double tare;
        public double Tare
        {
            get { return tare; }
            set
            {
                tare = value;
                OnPropertyChanged("Tare");
            }
        }

        //густая краска
        private double thickPaint;
        public double ThickPaint
        {
            get { return thickPaint; }
            set
            {
                thickPaint = value;
                OnPropertyChanged("ThickPaint");
            }
        }

        //функция копирования из листа итераций
        public void CopyFromIterationsColection(Iteration it)
        {
            Pm1 = it.mixes[0].MixPercent_1;
            Pm2 = it.mixes[1].MixPercent_1;
            Pm3 = it.mixes[2].MixPercent_1;
            Pm4 = it.mixes[3].MixPercent_1;
            Pm5 = it.mixes[4].MixPercent_1;
            Pm6 = it.mixes[5].MixPercent_1;
            Pm7 = it.mixes[6].MixPercent_1;
            Pm8 = it.mixes[7].MixPercent_1;
            Pm9 = it.mixes[8].MixPercent_1;
            Pm10 = it.mixes[9].MixPercent_1;
            Pm11 = it.mixes[10].MixPercent_1;
            Pm12 = it.mixes[11].MixPercent_1;
            Pm13 = it.mixes[12].MixPercent_1;
            Pm14 = it.mixes[13].MixPercent_1;
            Pm15 = it.mixes[14].MixPercent_1;
            Pm16 = it.mixes[15].MixPercent_1;

            Pm1_ = it.mixes[0].MixPercent_2;
            Pm2_ = it.mixes[1].MixPercent_2;
            Pm3_ = it.mixes[2].MixPercent_2;
            Pm4_ = it.mixes[3].MixPercent_2;
            Pm5_ = it.mixes[4].MixPercent_2;
            Pm6_ = it.mixes[5].MixPercent_2;
            Pm7_ = it.mixes[6].MixPercent_2;
            Pm8_ = it.mixes[7].MixPercent_2;
            Pm9_ = it.mixes[8].MixPercent_2;
            Pm10_ = it.mixes[9].MixPercent_2;
            Pm11_ = it.mixes[10].MixPercent_2;
            Pm12_ = it.mixes[11].MixPercent_2;
            Pm13_ = it.mixes[12].MixPercent_2;
            Pm14_ = it.mixes[13].MixPercent_2;
            Pm15_ = it.mixes[14].MixPercent_2;
            Pm16_ = it.mixes[15].MixPercent_2;
        }

        //функция проверки пустого заказа
        public bool EmptyOrder()
        {
            double summ = Pm1 + Pm2 + Pm3 + Pm4 + Pm5 + Pm6 + Pm7 + Pm8 + Pm9 + Pm10 + Pm11 + Pm12 + Pm13 + Pm14 + Pm15 + Pm16;
            if (summ == 0)
                return true;
            else
                return false;
        }




        public Order()
        {


            //инициализация названий миксов
            mixesName = new List<string>();
            for (int i = 1; i < 14; i++)
            {
                string mn = $"{i.ToString()}";
                mixesName.Add(mn);
            }
            string mn14 = "177";
            mixesName.Add(mn14);
            string mn15 = "199";
            mixesName.Add(mn15);
            string mn16 = "thin.";
            mixesName.Add(mn16);

            //инициализация веса миксов до теста нулями
            beforTestMixes = new List<double>();
            beforTestMixes.Capacity = 16;
            for (int i = 0; i < 16; i++)
                beforTestMixes.Add(0);
            
            //инициализация веса миксов после теста нулями
            afterTestMixes = new ObservableCollection<double>();
            for (int i = 0; i < 16; i++)
                afterTestMixes.Add(0);

            PercentPointer1 = 100;
            PercentPointer2 = 100;

            orderInfo = new OrderInfo();
            iterations = new ObservableCollection<Iteration>();
            estAndReal = new List<EstimatedAndRealWeight>();
            currentChanges = false;
            Tare = 0;
            PlusTare = 0;
            BeforeBrutto = 0;
            AfterBrutto = 0;
            percentCalculationOnOf = true;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class Proportion : INotifyPropertyChanged
    {
        public List<string> mixesName { get; set; }
        private double percentPointer1;
        public double PercentPointer1
        {
            get { return percentPointer1; }
            set
            {
                percentPointer1 = value;
                percentCalculation();
                OnPropertyChanged("PercentPointer1");
            }
        }
        private double pm1;
        public double Pm1
        {
            get { return pm1; }
            set
            {
                pm1 = value;
                OnPropertyChanged("Pm1");
            }
        }
        private double pm2;
        public double Pm2
        {
            get { return pm2; }
            set
            {
                pm2 = value;
                OnPropertyChanged("Pm2");
            }
        }
        private double pm3;
        public double Pm3
        {
            get { return pm3; }
            set
            {
                pm3 = value;
                OnPropertyChanged("Pm3");
            }
        }
        private double pm4;
        public double Pm4
        {
            get { return pm4; }
            set
            {
                pm4 = value;
                OnPropertyChanged("Pm4");
            }
        }

        private double pm5;
        public double Pm5
        {
            get { return pm5; }
            set
            {
                pm5 = value;
                OnPropertyChanged("Pm5");
            }
        }
        private double pm6;
        public double Pm6
        {
            get { return pm6; }
            set
            {
                pm6 = value;
                OnPropertyChanged("Pm6");
            }
        }
        private double pm7;
        public double Pm7
        {
            get { return pm7; }
            set
            {
                pm7 = value;
                OnPropertyChanged("Pm7");
            }
        }
        private double pm8;
        public double Pm8
        {
            get { return pm8; }
            set
            {
                pm8 = value;
                OnPropertyChanged("Pm8");
            }
        }
        private double pm9;
        public double Pm9
        {
            get { return pm9; }
            set
            {
                pm9 = value;
                OnPropertyChanged("Pm9");
            }
        }
        private double pm10;
        public double Pm10
        {
            get { return pm10; }
            set
            {
                pm10 = value;
                OnPropertyChanged("Pm10");
            }
        }
        private double pm11;
        public double Pm11
        {
            get { return pm11; }
            set
            {
                pm11 = value;
                OnPropertyChanged("Pm11");
            }
        }
        private double pm12;
        public double Pm12
        {
            get { return pm12; }
            set
            {
                pm12 = value;
                OnPropertyChanged("Pm12");
            }
        }
        private double pm13;
        public double Pm13
        {
            get { return pm13; }
            set
            {
                pm13 = value;
                OnPropertyChanged("Pm13");
            }
        }
        private double pm14;
        public double Pm14
        {
            get { return pm14; }
            set
            {
                pm14 = value;
                OnPropertyChanged("Pm14");
            }
        }
        private double pm15;
        public double Pm15
        {
            get { return pm15; }
            set
            {
                pm15 = value;
                OnPropertyChanged("Pm15");
            }
        }
        private double pm16;
        public double Pm16
        {
            get { return pm16; }
            set
            {
                pm16 = value;
                OnPropertyChanged("Pm16");
            }
        }
        public void percentCalculation()
        {
            double sum = Pm1 + Pm2 + Pm3 + Pm4 + Pm5 + Pm6 + Pm7 + Pm8 + Pm9 + Pm10 + Pm11 + Pm12 + Pm13 + Pm14 + Pm15;


            if (sum != 0)
            {
                Pm1 = Pm1 / sum * PercentPointer1;
                Pm2 = Pm2 / sum * PercentPointer1;
                Pm3 = Pm3 / sum * PercentPointer1;
                Pm4 = Pm4 / sum * PercentPointer1;
                Pm5 = Pm5 / sum * PercentPointer1;
                Pm6 = Pm6 / sum * PercentPointer1;
                Pm7 = Pm7 / sum * PercentPointer1;
                Pm8 = Pm8 / sum * PercentPointer1;
                Pm9 = Pm9 / sum * PercentPointer1;
                Pm10 = Pm10 / sum * PercentPointer1;
                Pm11 = Pm11 / sum * PercentPointer1;
                Pm12 = Pm12 / sum * PercentPointer1;
                Pm13 = Pm13 / sum * PercentPointer1;
                Pm14 = Pm14 / sum * PercentPointer1;
                Pm15 = Pm15 / sum * PercentPointer1;
                Pm16 = Pm16 / (sum) * PercentPointer1;
            }
        }
        public void UseProportion(Order or) 
        {
            or.M1 = Math.Round(Pm1, 1);
            or.M2 = Math.Round(Pm2, 1);
            or.M3 = Math.Round(Pm3, 1);
            or.M4 = Math.Round(Pm4, 1);
            or.M5 = Math.Round(Pm5, 1);
            or.M6 = Math.Round(Pm6, 1);
            or.M7 = Math.Round(Pm7, 1);
            or.M8 = Math.Round(Pm8, 1);
            or.M9 = Math.Round(Pm9, 1);
            or.M10 = Math.Round(Pm10, 1);
            or.M11 = Math.Round(Pm11, 1);
            or.M12 = Math.Round(Pm12, 1);
            or.M13 = Math.Round(Pm13, 1);
            or.M14 = Math.Round(Pm14, 1);
            or.M15 = Math.Round(Pm15, 1);
            or.M16 = Math.Round(Pm16, 1);

        }
        public Proportion(Order or)
        {
            mixesName = or.mixesName;
            Pm1 = or.SelectedIteration.mixes[0].MixPercent_1;
            Pm2 = or.SelectedIteration.mixes[1].MixPercent_1;
            Pm3 = or.SelectedIteration.mixes[2].MixPercent_1;
            Pm4 = or.SelectedIteration.mixes[3].MixPercent_1;
            Pm5 = or.SelectedIteration.mixes[4].MixPercent_1;
            Pm6 = or.SelectedIteration.mixes[5].MixPercent_1;
            Pm7 = or.SelectedIteration.mixes[6].MixPercent_1;
            Pm8 = or.SelectedIteration.mixes[7].MixPercent_1;
            Pm9 = or.SelectedIteration.mixes[8].MixPercent_1;
            Pm10 = or.SelectedIteration.mixes[9].MixPercent_1;
            Pm11 = or.SelectedIteration.mixes[10].MixPercent_1;
            Pm12 = or.SelectedIteration.mixes[11].MixPercent_1;
            Pm13 = or.SelectedIteration.mixes[12].MixPercent_1;
            Pm14 = or.SelectedIteration.mixes[13].MixPercent_1;
            Pm15 = or.SelectedIteration.mixes[14].MixPercent_1;
            Pm16 = or.SelectedIteration.mixes[15].MixPercent_1;
            PercentPointer1 = 100;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
