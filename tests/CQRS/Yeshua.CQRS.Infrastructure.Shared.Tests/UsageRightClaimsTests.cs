using System.Security.Claims;
using Dominio.Commercial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shared.Tests;

[TestClass]
public sealed class UsageRightClaimsTests
{
    [TestMethod]
    public void Signed_snapshot_roundtrips_and_period_check_uses_direct_claim()
    {
        var now = DateTimeOffset.UtcNow;
        var rights = new[] { new UsageRight("example.access", now.AddMonths(1).ToUnixTimeSeconds(), 0),
            new UsageRight("example.transcription", 0, 10) };
        var claims = new List<Claim>(); UsageRightClaims.AddTo(claims, rights);
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
        CollectionAssert.AreEqual(rights, UsageRightClaims.Read(user).ToArray());
        Assert.IsTrue(UsageRightClaims.HasPeriodClaim(user, "usageUntil.example.access", now));
        Assert.IsFalse(UsageRightClaims.HasPeriodClaim(user, "usageUntil.example.access", now.AddMonths(2)));
        Assert.IsFalse(UsageRightClaims.HasPeriodClaim(user, "usageUntil.example.transcription", now));
    }

    [TestMethod]
    public void Switching_applications_cannot_extend_the_original_session()
    {
        var end = DateTimeOffset.UtcNow.AddMinutes(3);
        var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim("exp", end.ToUnixTimeSeconds().ToString()) }));
        Assert.AreEqual(DateTimeOffset.FromUnixTimeSeconds(end.ToUnixTimeSeconds()).UtcDateTime,
            UsageRightClaims.TokenExpiry(user, DateTime.UtcNow.AddDays(1)));
    }

    [TestMethod]
    public void Malformed_and_negative_snapshots_do_not_grant_usage()
    {
        Assert.AreEqual(0, UsageRightClaims.Read("not-json").Count);
        Assert.AreEqual(0, UsageRightClaims.Read("[{\"Resource\":\"test\",\"Until\":0,\"GrantedUnits\":-1}]").Count);
        Assert.AreEqual(0, UsageRightClaims.Read(new string('x', 16001)).Count);
    }
}
