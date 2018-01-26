using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace EasyUiTool
{
    public class VideoDialog : UiBase
    {
        #region members

        //up
        private Text txtTitle;
        private Button btnFullSc, btnClose;
        //mid
        private VideoPlayer vPlayer;
        private Slider sliderSchelude;
        //down
        private Button btnReplay, btnLeft, btnPause, btnRight;
        private Slider sliderVolume;

        #endregion

        #region funcs

        private void Awake()
        {
            init();
        }
        void init()
        {
            //up
            txtTitle = transform.Find("up/txtTitle").GetComponent<Text>();
            btnFullSc = transform.Find("up/btnFullSc").GetComponent<Button>();
            btnClose = transform.Find("up/btnClose").GetComponent<Button>();
            //mid
            vPlayer = transform.Find("mid/midMid").GetComponent<VideoPlayer>();
            sliderSchelude = transform.Find("mid/midMid/imgMovie/sliderSchelude").GetComponent<Slider>();
            //down
            btnReplay = transform.Find("down/btnReplay").GetComponent<Button>();
            btnLeft = transform.Find("down/btnLeft").GetComponent<Button>();
            btnPause = transform.Find("down/btnPause").GetComponent<Button>();
            btnRight = transform.Find("down/btnRight").GetComponent<Button>();
            sliderVolume = transform.Find("down/volume/sliderVolume").GetComponent<Slider>();

            btnClose.onClick.AddListener(Close);

            ResetSelf();
        }



        #endregion

        #region set



        #endregion

        #region override

        public override void ResetSelf()
        {
            base.ResetSelf();

        }

        #endregion

    }
}
