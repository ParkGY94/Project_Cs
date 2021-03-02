using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PAIX_NMF_DEV;

namespace Pressure_Sensor_EOL
{
    class NMFDIO
    {
        // 연결되는 장치 번호 'Rotary switch 번호이자 IP번호
        bool m_bDevConnect;     // 장치 연결 상태 확인
        Thread TdWatchDIO;
        public NMF.TNMF_ALL_STS tAllStatus = new NMF.TNMF_ALL_STS();   // 전체상태 구조체
        public NMF.TNMF_COMPO tCompo = new NMF.TNMF_COMPO();           // 장치구성정보 구조체
        string[] BrdType;
        public NMFDIO()
        {
            m_bDevConnect = false;
            BrdType = new string[] { "", "DO", "DI", "AI", "AO", "AIO" };
            TdWatchDIO = new Thread(new ThreadStart(DoWatch));
        }

        public void DoWatch()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(50);
                if (m_bDevConnect == false) break;
                //this.Invoke(new delegateUpdateOutIn(UpdateStatus));
            }
        }

        public bool Connect(short nDevNo, short nIP1, short nIP2, short nIP3, int num)
        {
            bool flag = false;

            TdWatchDIO = new Thread(new ThreadStart(DoWatch));

            short nRet;

            try
            {
                nRet = NMF.nmf_PingCheck(nDevNo, nIP1, nIP2, nIP3, 200);
                if (nRet != 0)
                {
                    return flag;
                }

                nRet = NMF.nmf_Connect(nDevNo, nIP1, nIP2, nIP3);
                if (nRet == 0)
                {
                    m_bDevConnect = true;
                    switch (TdWatchDIO.ThreadState)
                    {
                        case ThreadState.Stopped:
                            TdWatchDIO = new Thread(new ThreadStart(DoWatch));
                            break;
                        case ThreadState.Unstarted:
                            break;
                        default:
                            TdWatchDIO.Abort();
                            // TdWatchSensor.Join();
                            while (TdWatchDIO.ThreadState != ThreadState.Stopped) { }
                            break;
                    }
                    TdWatchDIO.Start();
                    flag = true;
                }
            }
            catch (Exception ex)
            {

            }
            return flag;
        }

        public void Disconnect(short nDevNo)
        {
            NMF.nmf_Disconnect(nDevNo);
            TdWatchDIO.Abort();
            TdWatchDIO.Join();
            while(TdWatchDIO.ThreadState != ThreadState.Stopped) { }
        }
    }
}
