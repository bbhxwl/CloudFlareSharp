using Newtonsoft.Json;

namespace CloudFlareSharp.Api.V2.RealtimeKitApi.MeetingsModels
{
    public enum Region
    {
        [JsonProperty("ap-south-1")] ApSouth1,
        [JsonProperty("ap-southeast-1")] ApSoutheast1,
        [JsonProperty("us-east-1")] UsEast1,
        [JsonProperty("eu-central-1")] EuCentral1
    }

    public enum VideoCodec
    {
        [JsonProperty("H264")] H264,
        [JsonProperty("VP8")] VP8
    }

    public enum AudioCodec
    {
        [JsonProperty("MP3")] MP3,
        [JsonProperty("AAC")] AAC
    }

    public enum AudioChannel
    {
        [JsonProperty("mono")] Mono,
        [JsonProperty("stereo")] Stereo
    }

    public enum StorageType
    {
        [JsonProperty("aws")] Aws,
        [JsonProperty("azure")] Azure,
        [JsonProperty("digitalocean")] DigitalOcean,
        [JsonProperty("gcs")] Gcs,
        [JsonProperty("sftp")] Sftp
    }

    public enum AuthMethod
    {
        [JsonProperty("KEY")] Key,
        [JsonProperty("PASSWORD")] Password
    }

    public enum Language
    {
        [JsonProperty("en-US")] EnUs,
        [JsonProperty("en-IN")] EnIn,
        [JsonProperty("de")] De,
        [JsonProperty("hi")] Hi,
        [JsonProperty("sv")] Sv,
        [JsonProperty("ru")] Ru,
        [JsonProperty("pl")] Pl,
        [JsonProperty("el")] El,
        [JsonProperty("fr")] Fr,
        [JsonProperty("nl")] Nl
    }

    public enum TextFormat
    {
        [JsonProperty("plain_text")] PlainText,
        [JsonProperty("markdown")] Markdown
    }

    public enum SummaryType
    {
        [JsonProperty("general")] General,
        [JsonProperty("team_meeting")] TeamMeeting,
        [JsonProperty("sales_call")] SalesCall,
        [JsonProperty("client_check_in")] ClientCheckIn,
        [JsonProperty("interview")] Interview,
        [JsonProperty("daily_standup")] DailyStandup,
        [JsonProperty("one_on_one_meeting")] OneOnOneMeeting,
        [JsonProperty("lecture")] Lecture,
        [JsonProperty("code_review")] CodeReview
    }

    public class CreateRequest
    {
        /// <summary>
        /// 会议标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 应该创建此会议的区域，ap-south-1,ap-southeast-1,us-east-1,eu-central-1,null
        /// </summary>
        [JsonProperty("preferred_region")]
        public string PreferredRegion { get; set; } = "ap-south-1";

        /// <summary>
        /// 指定当有人加入会议时是否应该立即开始录制
        /// </summary>
        [JsonProperty("record_on_start")]
        public bool? RecordOnStart { get; set; }

        /// <summary>
        /// 指定会议开始时是否应该开始直播
        /// </summary>
        [JsonProperty("live_stream_on_start")]
        public bool? LiveStreamOnStart { get; set; }

        [JsonProperty("recording_config")]
        public RecordingConfig RecordingConfig { get; set; }

        [JsonProperty("live_streaming_config")]
        public LiveStreamingConfig LiveStreamingConfig { get; set; }

        [JsonProperty("ai_config")]
        public AIConfig AIConfig { get; set; }

        /// <summary>
        /// 如果会议设置为保持聊天记录，会议聊天记录将在会议空间中保留一周
        /// </summary>
        [JsonProperty("persist_chat")]
        public bool? PersistChat { get; set; }

        /// <summary>
        /// 使用转录自动生成会议摘要
        /// </summary>
        [JsonProperty("summarize_on_end")]
        public bool? SummarizeOnEnd { get; set; }
    }

    public class RecordingConfig
    {
        /// <summary>
        /// 指定以秒为单位的最大录制时长(60-86400)
        /// </summary>
        [JsonProperty("max_seconds")]
        public int MaxSeconds { get; set; }

        /// <summary>
        /// 在录制文件名的开头添加前缀
        /// </summary>
        [JsonProperty("file_name_prefix")]
        public string FileNamePrefix { get; set; }

        [JsonProperty("video_config")]
        public VideoConfig VideoConfig { get; set; }

        [JsonProperty("audio_config")]
        public AudioConfig AudioConfig { get; set; }

        [JsonProperty("storage_config")]
        public StorageConfig StorageConfig { get; set; }

        [JsonProperty("realtimekit_bucket_config")]
        public RealtimekitBucketConfig RealtimekitBucketConfig { get; set; }
    }

    public class VideoConfig
    {
        [JsonProperty("codec")]
        public VideoCodec Codec { get; set; }

        /// <summary>
        /// 录制视频的宽度（像素）(1-1920)
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// 录制视频的高度（像素）(1-1920)
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("watermark")]
        public object Watermark { get; set; }

        [JsonProperty("export_file")]
        public bool ExportFile { get; set; }
    }

    public class AudioConfig
    {
        [JsonProperty("codec")]
        public AudioCodec Codec { get; set; }

        [JsonProperty("channel")]
        public AudioChannel Channel { get; set; }

        [JsonProperty("export_file")]
        public bool ExportFile { get; set; }
    }

    public class StorageConfig
    {
        [JsonProperty("type")]
        public StorageType Type { get; set; }

        [JsonProperty("access_key")]
        public string AccessKey { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("auth_method")]
        public AuthMethod? AuthMethod { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("port")]
        public int? Port { get; set; }

        [JsonProperty("private_key")]
        public string PrivateKey { get; set; }
    }

    public class RealtimekitBucketConfig
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }

    public class LiveStreamingConfig
    {
        [JsonProperty("rtmp_url")]
        public string RtmpUrl { get; set; }
    }

    public class AIConfig
    {
        [JsonProperty("transcription")]
        public TranscriptionConfig Transcription { get; set; }

        [JsonProperty("summarization")]
        public SummarizationConfig Summarization { get; set; }
    }

    public class TranscriptionConfig
    {
        [JsonProperty("keywords")]
        public string[] Keywords { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("profanity_filter")]
        public bool ProfanityFilter { get; set; }
    }

    public class SummarizationConfig
    {
        /// <summary>
        /// 设置会议摘要的最大字数(150-1000)
        /// </summary>
        [JsonProperty("word_limit")]
        public int WordLimit { get; set; }

        [JsonProperty("text_format")]
        public TextFormat TextFormat { get; set; }

        [JsonProperty("summary_type")]
        public SummaryType SummaryType { get; set; }
    }
}