export class TweetObject {
  constructor(
    text,
    username,
    screenName,
    createdAt,
    retweetCount,
    replyCount,
    likeCount,
    profileImageUrl,
    videoPreviewImageUrl,
    imageUrl
  ) {
    this.text = text;
    this.user = username;
    this.screenName = screenName;
    this.createdAt = createdAt;
    this.retweetCount = retweetCount;
    this.replyCount = replyCount;
    this.likeCount = likeCount;
    this.profileImageUrl = profileImageUrl;
    this.videoPreviewImageUrl = videoPreviewImageUrl;
    this.imageUrl = imageUrl;
  }
}
