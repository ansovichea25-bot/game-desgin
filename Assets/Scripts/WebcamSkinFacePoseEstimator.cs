using UnityEngine;

/// <summary>
/// Minimal stub for webcam skin-based face pose estimation.
/// This implementation intentionally returns invalid samples by default
/// and provides no-op lifecycle methods so the editor demo compiles.
/// Replace with a real estimator implementation if available.
/// </summary>
public sealed class WebcamSkinFacePoseEstimator
{
    public struct Sample
    {
        public bool Valid;

        public float BboxNormH;
        public float BboxNormW;

        public float CenterXN;
        public float BboxCenterXN;
        public float CenterYN;

        public float PitchDeg;
        public float YawDeg;
        public float RollDeg;
    }

    public WebcamSkinFacePoseEstimator()
    {
    }

    /// <summary>
    /// Attempts to estimate face pose from the provided webcam texture.
    /// This stub always returns false and an invalid sample. Replace with real logic.
    /// </summary>
    public bool TryEstimate(WebCamTexture webcam, int processWidth, bool horizontalMirrorSelfieStyle,
        int minSkinPixels, float roiMarginX, float roiMarginY,
        float yawMaxDegreesFromCenter, float pitchMaxDegreesFromCenter, float rollEllipseGain,
        out Sample sample)
    {
        sample = default;
        sample.Valid = false;
        return false;
    }

    /// <summary>
    /// Release any native or GPU resources. No-op in stub.
    /// </summary>
    public void Release()
    {
    }
}
